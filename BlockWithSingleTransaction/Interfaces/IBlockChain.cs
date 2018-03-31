using System;
using BlockWithSingleTransaction;

namespace BlockWithSingleTransaction.Interfaces {

    public interface IBlockChain {
        void AcceptBlock(IBlock block);
        void VerifyChain();
    }

}