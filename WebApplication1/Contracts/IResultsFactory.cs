using System;
using System.Collections.Generic;

namespace WebApplication1.Contracts
{
    public interface IResultsFactory
    {
        string GetRates();

        string GetTransactions();

        double GetTransSum(string skuId);
    }
}
