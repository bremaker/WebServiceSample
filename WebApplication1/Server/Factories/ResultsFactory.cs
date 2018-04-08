using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Contracts;
using WebApplication.Entities;
using WebApplication.Utils;

namespace WebApplication.Factories
{
    /// <summary>
    /// Calculates application results (Domain)
    /// </summary>
    public class ResultsFactory : IResultsFactory
    {
        #region CONST

        private const string RATES_ERROR = "No rate data available";
        private const string TRANS_ERROR = "No transaction data available";
        private const string AMOUNT_ERROR = "Unable to convert amount";
        private const int DECIMALS = 2;
        private const string RATES_SOURCE = "http://quiet-stone-2094.herokuapp.com/rates.json";
        private const string TRANS_SOURCE = "http://quiet-stone-2094.herokuapp.com/transactions.json";

        #endregion

        #region PRIVATE MEMBERS

        private string _currency;
        private IBasicRepo _ratesRepo;
        private IBasicRepo _transRepo;
        private ISource _source;
        private Dictionary<string, decimal> _currencyRates;

        #endregion

        #region PULBIC

        public ResultsFactory(IBasicRepo ratesRepo, IBasicRepo transRepo, ISource source, string currency)
        {
            _currency = currency;
            _ratesRepo = ratesRepo;
            _transRepo = transRepo;
            _source = source;
        }

        public List<Rate> GetRates(bool _useStoredData = false)
        {
            Log.Write("GetAllRates");

            string data = _useStoredData ? GetData(_ratesRepo) : GetData(RATES_SOURCE, _ratesRepo);
            List<Rate> result = JsonConvert.DeserializeObject<List<Rate>>(data);
            return result;
        }

        public List<Transaction> GetTransactions(bool _useStoredData = false)
        {
            Log.Write("GetAllTransactions");

            string data = _useStoredData ? GetData(_transRepo) : GetData(TRANS_SOURCE, _transRepo);
            List<Transaction> result = JsonConvert.DeserializeObject<List<Transaction>>(data);
            return result;
        }

        public TransactionsSum GetTransSum(string skuId)
        {
            Log.Write("GetTransactionsSum: " + skuId);

            TransactionsSum result = new TransactionsSum();

            // Load necessary data
            List<Transaction> transactions = GetTransactions(true);
            List<Rate> rates = GetRates(true);

            if(rates == null || rates.Count == 0)
            {
                Log.Write(RATES_ERROR);
                throw new Exception(RATES_ERROR);
            }

            if(transactions == null)
            {
                Log.Write(TRANS_ERROR);
                throw new Exception(TRANS_ERROR);
            }

            // Calculate transformations to applications currency
            _currencyRates = CalculateRates(rates, _currency);

            // Filter by sku and add all amounts based on the application currency
            result.list = transactions.Where(t => t.sku == skuId).ToList();
            foreach (Transaction trans in result.list)
            {
                trans.amount = CalulateAmount(trans);
                trans.currency = _currency;
                result.sum += trans.amount;
            }

            result.sum = Math.Round(result.sum, DECIMALS);

            return result;
        }

        #endregion

        #region PRIVATE

        /// <summary>
        /// Calculates all rates to the same currency.
        /// </summary>
        /// <param name="rates">Rates list. Implements a rates graph with bidirectional edges and no cycles.</param>
        /// <param name="currency">Currency in which the dictionary is based.</param>
        /// <returns>A dictionary of rates to the same currency.</returns>
        private Dictionary<string, decimal> CalculateRates(IList<Rate> rates, string currency)
        {
            IEnumerable<Rate> toCurrencyRates, formCurrencyRates;
            Dictionary<string, decimal> indirectRates;
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();

            // Get direct rates to currency (graph edges)
            toCurrencyRates = rates.Where(rate => rate.to == currency);

            if (toCurrencyRates.Count() > 0)
            {
                // Remove unnecessary rates (bidirectional edges)
                formCurrencyRates = rates.Where(rate => rate.from != currency);

                foreach (Rate r in toCurrencyRates)
                {
                    // Add direct rates
                    result.Add(r.from, r.rate);

                    // Calculate and add indirect rates
                    indirectRates = CalculateRates(formCurrencyRates.ToList(), r.from);
                    foreach (KeyValuePair<string, decimal> entry in indirectRates)
                    {
                        result.Add(entry.Key, entry.Value * r.rate);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Transforms the amount of a transaction to the current currency.
        /// </summary>
        /// <param name="trans">Transaction</param>
        /// <returns> The amount based on current currency </returns>
        private decimal CalulateAmount(Transaction trans)
        {
            decimal result = 0;

            if (trans.currency == _currency)
            {
                result = trans.amount;
            }
            else if (_currencyRates.ContainsKey(trans.currency))
            {
                result = trans.amount * _currencyRates[trans.currency];
            }
            else
            {
                Log.Write(AMOUNT_ERROR);
                throw new Exception(AMOUNT_ERROR);
            }

            return result;
        }

        /// <summary>
        /// Get data sotred on repository
        /// </summary>
        /// <param name="repository">Repository where the data is stored</param>
        /// <returns>Data in a string</returns>
        private string GetData(IBasicRepo repository)
        {
            return repository.ReadData();
        }
        /// <summary>
        /// Get data from a url and sotred it on the repository. 
        /// If the url is not reachable the data from the repository will be returned.
        /// </summary>
        /// <param name="url">Data source</param>
        /// <param name="repository">Repository where the data is stored</param>
        /// <returns>Data in a string</returns>
        private string GetData(string url, IBasicRepo repository)
        {
            string data;

            data = _source.GetDataFromSource(url);
            if (data != "")
            {
                repository.StoreData(data);
            }
            else
            {
                data = repository.ReadData();
            }

            return data;
        }

        #endregion
    }
}
