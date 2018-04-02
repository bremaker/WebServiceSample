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

        #region GET

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

        #region DELETE

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                if (!products.DeleteProduct(id))
                {
                    return NotFound();
                }

                return Ok(id);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region POST

        [HttpPost]
        public IHttpActionResult AddProduct(Product request)
        {
            try
            {
                products.AddProduct(request);
                return Ok(products.GetAll());
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        #endregion

    }
}