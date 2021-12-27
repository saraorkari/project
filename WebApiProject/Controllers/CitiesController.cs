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

    public class CitiesController : ApiController
    {
        CityService CityService = new CityService();

        // GET: api/Areas
        public List<CityDTO> Get()
        {
            return CityService.Get();
        }

        // GET: api/Areas/5
        public CityDTO Get(int id)
        {
            return CityService.Get(id);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(CityDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            //if (x.Id == 0)
            //    return NotFound();
            return Ok(CityService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, CityDTO x)
        {
            return Ok(CityService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            CityService.Delete(id);
        }
    }
}
