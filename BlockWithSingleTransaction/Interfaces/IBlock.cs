using System;
using BlockWithSingleTransaction;

namespace BlockWithSingleTransaction.Interfaces
{
    public interface IBlock
    {
        string ClaimNumber { get; set; }
        
        decimal SettlementAmount { get; set; }

        DateTime SettlementDate { get; set; }

        string CarRegistration { get; set; }
        
        int Mileage { get; set; }

        ClaimType ClaimType { get; set; }

        int BlockNumber { get; set; }
        
        DateTime BlockCreationDate { get; set; }
        
        string PrevBlockHash { get; set; }
        
        string BlockHash { get; set; }

        IBlock NextBlock { get; set; }

        string CalculateBlockHash(string prevBlockHash);

        //commit block
        void SetBlockHash(IBlock parent);


        bool IsValidChain(string prevBlockHash, bool verbose);

    }
}