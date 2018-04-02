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
    public class ProductsController : ApiController
    {
        static ProductManager products = new ProductManager(10);

        private const string RATES_SOURCE = "http://quiet-stone-2094.herokuapp.com/rates.json";
        private const string TRANS_SOURCE = "http://quiet-stone-2094.herokuapp.com/transactions.json";

        #region GET

        [HttpGet]
        public IEnumerable<Product> GetAllRates()
        {
            SourceManager manager = new SourceManager(RATES_SOURCE, "rates.txt");
            return products.GetAll();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllTransactions()
        {
            return products.GetAll();
        }

        [HttpGet]
        public IEnumerable<Product> GetTransactionsSum(string skuId)
        {
            return products.GetAll();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products.GetAll();
        }

        [HttpGet]
        public IQueryable<Product> GetProducts(int top, string orderby)
        {
            return products.GetAll().AsQueryable().OrderBy(prod => prod.Name);
            //return products.GetAll().AsQueryable();
            
        }

        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            try
            {
                Product product = products.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
                //return new ExceptionResult(e, this);
            }
        }

        #endregion

    }
}