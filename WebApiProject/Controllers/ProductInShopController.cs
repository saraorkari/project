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

    public class ProductInShopController : ApiController
    {
        ProductInShopService ProductInShopService = new ProductInShopService();

        // GET: api/Areas
        public List<ProductInShopDTO> Get()
        {
            return ProductInShopService.Get();
        }

        // GET: api/Areas/5
        public List<ProductInShopDTO> Get(int shopId)
        {
            return ProductInShopService.Get(shopId);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(ProductInShopDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            //if (x.Id == 0)
            //    return NotFound();
            return Ok(ProductInShopService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, ProductInShopDTO x)
        {
            return Ok(ProductInShopService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            ProductInShopService.Delete(id);
        }
    }
}
