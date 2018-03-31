using System;
using System.Globalization;
using System.Text;
using BlockWithSingleTransaction.Interfaces;
using CryptoUtilities;

namespace BlockWithSingleTransaction
{

    public class Block : IBlock
    {
        public string ClaimNumber { get; set; }
        public decimal SettlementAmount { get; set; }
        public DateTime SettlementDate { get; set; }
        public string CarRegistration { get; set; }
        public int Mileage { get; set; }
        public ClaimType ClaimType { get; set; }
        
        public int BlockNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PrevBlockHash { get; set; }
        public string BlockHash { get; set; }
        public IBlock NextBlock { get; set; }

        public Block(
            int blockNumber,
            string claimNumber,
            decimal settlementAmount,
            DateTime settlementDate,
            int mileage,
            string carRegistration,
            ClaimType claimType,
            IBlock parent 
        ) {
            BlockNumber = blockNumber;
            ClaimNumber = claimNumber;
            SettlementAmount = settlementAmount;
            SettlementDate = settlementDate;
            CarRegistration = carRegistration;
            Mileage = mileage;
            ClaimType = claimType;
            CreatedDate = DateTime.UtcNow;
            SetBlockHash(parent);
        }
        public string CalculateBlockHash(string prevBlockHash)
        {
            var txHash = ClaimNumber + SettlementAmount + SettlementDate + CarRegistration + Mileage + ClaimType;
            var blockHeader = BlockNumber + CreatedDate.ToString(CultureInfo.CurrentCulture) + prevBlockHash;
            var combined = txHash + blockHeader;

            return Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(combined)));
        }

        public void SetBlockHash(IBlock parent)
        {
            if (parent != null)
            {
                PrevBlockHash = parent.BlockHash;
                parent.NextBlock = this;
            }
            else
            {
                PrevBlockHash = null;
            }

            BlockHash = CalculateBlockHash(PrevBlockHash);
        }

        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            var isValid = true;

            var newBlockHash = CalculateBlockHash(prevBlockHash);
            
            if (newBlockHash != BlockHash)
            {
                isValid = false;
            }
            else
            {
                isValid = PrevBlockHash == prevBlockHash; 
            }

            PrintVerificationMessage(verbose, isValid);

            if (NextBlock != null)
                return NextBlock.IsValidChain(newBlockHash, verbose);

            return isValid;
        }
        
        private void PrintVerificationMessage(bool verbose, bool isValid)
        {
            if (verbose)
            {
                if (!isValid)
                {
                    Console.WriteLine("Block Number " + BlockNumber + " : FAILED VERIFICATION");
                }
                else
                {
                    Console.WriteLine("Block Number " + BlockNumber + " : PASS VERIFICATION");
                }
            }
        }
        
        
    }
}