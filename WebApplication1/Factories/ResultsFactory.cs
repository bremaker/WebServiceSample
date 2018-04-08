using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplication1.Contracts;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Sources
{
    public class ResultsFactory : IResultsFactory
    {
        private const string RATES_SOURCE = "http://quiet-stone-2094.herokuapp.com/rates.json";
        private const string TRANS_SOURCE = "http://quiet-stone-2094.herokuapp.com/transactions.json";
        private const string CURRENCY = "EUR";

        private IBasicRepo _ratesRepo;
        private IBasicRepo _transRepo;
        private ISource _source;

        public ResultsFactory(IBasicRepo ratesRepo, IBasicRepo transRepo, ISource source)
        {
            _ratesRepo = ratesRepo;
            _transRepo = transRepo;
            _source = source;
        }

        public List<Rate> GetRates()
        {
            string data = GetData(RATES_SOURCE, _ratesRepo);
            List<Rate> result = JsonConvert.DeserializeObject<List<Rate>>(data);
            return result;
        }

        public List<Transaction> GetTransactions()
        {
            string data = GetData(TRANS_SOURCE, _transRepo);
            List<Transaction> result = JsonConvert.DeserializeObject<List<Transaction>>(data);
            return result;
        }

        public decimal GetTransSum(string skuId)
        {
            decimal result = 0;
            IEnumerable<Transaction> filteredTrans;
            List<Rate> rates = GetRates();
            List<Transaction> trans = GetTransactions();

            if (trans != null && trans.Count > 0)
            {
                filteredTrans = trans.Where(t => t.sku == skuId);
                result = filteredTrans.Sum(t => CalulateAmountInEur(t, rates));
            }

            return result;
        }

        private Dictionary<string, decimal> CalculateRates(List<Rate> rates, string currency)
        {
            Dictionary<string, decimal> ratesToCurrency = new Dictionary<string, decimal>();

            IEnumerable<Rate> filteredRates;
            filteredRates = rates.Where(r => r.to == currency);

            foreach(Rate r in filteredRates)
            {
                ratesToCurrency.Add(r.from, r.rate);
                rates.Remove(r);
                CalculateRates(rates, r.from);
            }

            return ratesToCurrency;
        }

        private decimal CalulateAmountInEur(Transaction trans, List<Rate> rates)
        {
            decimal result;

            if(trans.currency == CURRENCY)
            {
                result = trans.amount;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        private string GetData(string url, IBasicRepo repository)
        {
            string data;

            //data = _source.GetDataFromSource(url);
            //if (data != "")
            //{
            //    repository.StoreData(data);
            //}
            //else
            //{
                data = repository.ReadData();
            //}

            return data;
        }
    }
}
