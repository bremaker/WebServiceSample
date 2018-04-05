using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication1.Models;

namespace ProductsApp.Controllers
{
    public class RatesController : ApiController
    {
        private const string RATES_SOURCE = "http://quiet-stone-2094.herokuapp.com/rates.json";
        private const string TRANS_SOURCE = "http://quiet-stone-2094.herokuapp.com/transactions.json";

        #region GET

        [HttpGet]
        public IEnumerable<Rates> GetAllRates()
        {
            List<Rates> rates = new List<Rates>();
            // SourceManager manager = new SourceManager(RATES_SOURCE, "rates.txt");
            Console.WriteLine("RATES");

            return rates;
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllTransactions()
        //{
        //    return products.GetAll();
        //}

        //[HttpGet]
        //public IEnumerable<Product> GetTransactionsSum(string skuId)
        //{
        //    return products.GetAll();
        //}

        #endregion

    }
}