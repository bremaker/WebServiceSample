using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Entities;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    /// <summary>
    /// Transactions service api
    /// </summary>
    public class TransController : ApiController
    {
        #region GET

        [HttpGet]
        public HttpResponseMessage GetAllTransactions()
        {
            List<Transaction> result;
            HttpResponseMessage response;

            try
            {
                result = Install.Factory.GetTransactions();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                result = new List<Transaction>();
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString());
            }

            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetTransactionsSum(string skuId)
        {
            HttpResponseMessage response;
            TransactionsSum result;

            try
            {
                result = Install.Factory.GetTransSum(skuId);

                if (result.sum != 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    // Supposing that there are no negative transactions
                    response = Request.CreateResponse(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString());
                }
            }
            catch
            {
                result = new TransactionsSum();
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString());
            }

            return response;
        }

        #endregion

    }
}