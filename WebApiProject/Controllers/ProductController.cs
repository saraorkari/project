using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
using System.Web.Http.Cors;

namespace WebApiProject.Controllers
{
    [EnableCors(methods: "*", origins: "*", headers: "*")]

    public class ProductController : ApiController
    {
        ProductService ProductService = new ProductService();

        // GET: api/Areas
        public List<ProductDTO> Get()
        {
            return ProductService.Get();
        }

        // GET: api/Areas/5
        //public List<ProductDTO> Get(int categoryId)
        //{
        //    return ProductService.Get(categoryId);
        //}
        public List<ProductWhithShop> Get(int categoryId)
        {
            return ProductService.Get(categoryId);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(ProductDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            //if (x.Id == 0)
            //    return NotFound();
            return Ok(ProductService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, ProductDTO x)
        {
            return Ok(ProductService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            ProductService.Delete(id);
        }
    }
}
