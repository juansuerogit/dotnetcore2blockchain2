using System;
using BlockWithSingleTransaction.Interfaces;

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
        public DateTime BlockCreationDate { get; set; }
        public string PrevBlockHash { get; set; }
        public string BlockHash { get; set; }
        public IBlock NextBlock { get; set; }

        public string CalculateBlockHash(string prevBlockHash)
        {
            throw new NotImplementedException();
        }

        public void SetBlockHash(IBlock parent)
        {
            throw new NotImplementedException();
        }

        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            throw new NotImplementedException();
        }
    }
}