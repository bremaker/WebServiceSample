using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Contracts;
using WebApplication1.Entities;
using WebApplication1.Repositories;
using WebApplication1.Sources;

namespace ProductsApp.Controllers
{
    public class RatesController : ApiController
    {
        #region GET

        [HttpGet]
        public IEnumerable<Rate> GetAllRates()
        {
            string data;
            IList<Rate> rates;

            data = Singleton.Factory.GetRates();
            rates = JsonConvert.DeserializeObject<List<Rate>>(data);

            return rates;
        }

        #endregion

    }
}