using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Entities;
using WebApplication.Utils;

namespace WebApplication.Controllers
{
    /// <summary>
    /// Rates service api
    /// </summary>
    public class RatesController : ApiController
    {
        #region GET

        [HttpGet]
        public HttpResponseMessage GetAllRates()
        {
            HttpResponseMessage response;
            List<Rate> result;

            try
            {
                result = Install.Factory.GetRates();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                result = new List<Rate>();
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString());
            }

            return response;
        }

        #endregion

    }
}