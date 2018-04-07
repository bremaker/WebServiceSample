using System;
using System.Net;
using WebApplication1.Contracts;
using WebApplication1.Repositories;

namespace WebApplication1.Sources
{
    public class ResultsFactory : IResultsFactory
    {
        private const string RATES_SOURCE = "http://quiet-stone-2094.herokuapp.com/rates.json";
        private const string TRANS_SOURCE = "http://quiet-stone-2094.herokuapp.com/transactions.json";

        private IBasicRepo _ratesRepo;
        private IBasicRepo _transRepo;
        private ISource _source;

        public ResultsFactory(IBasicRepo ratesRepo, IBasicRepo transRepo, ISource source)
        {
            _ratesRepo = ratesRepo;
            _transRepo = transRepo;
            _source = source;
        }

        public string GetRates()
        {
            string data;

            data = _source.GetDataFromSource(RATES_SOURCE);
            if (data != "")
            {
                _ratesRepo.StoreData(data);
            }
            else
            {
                data = _ratesRepo.ReadData();
            }

            return data;
        }

        public string GetTransactions()
        {
            string data;

            data = _source.GetDataFromSource(TRANS_SOURCE);
            if (data != "")
            {
                _transRepo.StoreData(data);
            }
            else
            {
                data = _transRepo.ReadData();
            }

            return data;
        }

        public double GetTransSum(string skuId)
        {
            return 0;
        }
    }
}
