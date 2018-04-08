using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Contracts;
using WebApplication1.Entities;
using WebApplication1.Repositories;
using WebApplication1.Sources;

namespace ProductsApp.Controllers
{
    public class TransController : ApiController
    {
        #region GET

        [HttpGet]
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return Singleton.Factory.GetTransactions();
        }

        [HttpGet]
        public decimal GetTransactionsSum(string skuId)
        {
            return Singleton.Factory.GetTransSum(skuId);
        }

        #endregion

    }
}