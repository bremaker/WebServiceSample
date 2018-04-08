using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Contracts
{
    public interface IResultsFactory
    {
        /// <summary>
        /// Get list of rates
        /// </summary>
        /// <param name="_useStoredData">If return the data from the repository (true) or from the data source (false)</param>
        /// <returns></returns>
        List<Rate> GetRates(bool _useStoredData = false);

        /// <summary>
        /// Get list of transactions
        /// </summary>
        /// <param name="_useStoredData">If return the data from the repository (true) or from the data source (false)</param>
        /// <returns></returns>
        List<Transaction> GetTransactions(bool _useStoredData = false);

        /// <summary>
        /// Get the list of transactions, related to an sku and based on application currency, 
        /// and the amount addition of all transactions.
        /// </summary>
        /// <param name="skuId"></param>
        /// <returns></returns>
        TransactionsSum GetTransSum(string skuId);
    }
}
