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
    public class ShopController : ApiController
    {
        ShopService ShopService = new ShopService();

        // GET: api/Areas
        public List<ShopDTO> Get()
        {
            return ShopService.Get();
        }

        // GET: api/Areas/5
        public IHttpActionResult Get(string Name, string Password)
        {
            ShopDTO x = ShopService.Get(Name, Password);
            if (x != null)
                return Ok(x);
            return BadRequest();
        }
       
        // POST: api/Areas
        [HttpPost]
        
        public IHttpActionResult Post(ShopDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            //if (x.Id == 0)
            //    return NotFound();
            string mass="";
            x = ShopService.Post(x, ref mass);
            if (x != null)
                return Ok(x);
            return BadRequest(mass);
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, ShopDTO x)
        {
            return Ok(ShopService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            ShopService.Delete(id);
        }
    }
}
