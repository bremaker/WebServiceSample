using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1.Contracts
{
    public interface IResultsFactory
    {
        List<Rate> GetRates();

        List<Transaction> GetTransactions();

        decimal GetTransSum(string skuId);
    }
}
