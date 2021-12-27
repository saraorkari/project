using DTO;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiProject.Controllers
{
    [EnableCors(methods: "*", origins: "*", headers: "*")]

    public class AreasController : ApiController
    {
        AreaService AreaService = new AreaService();
       
        // GET: api/Areas
        public List<AreaDTO> Get()
        {
          return  AreaService.Get();
        }

        // GET: api/Areas/5
        public AreaDTO Get(int id)
        {
            return AreaService.Get(id);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(AreaDTO a)
        {
            if(a==null)
            {
                return BadRequest("לא נשלח מידע");
            }
            //if (a.Id == 0)
            //    return NotFound();
            return Ok( AreaService.Post(a));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id,AreaDTO a)
        {
            return Ok(AreaService.Put(id,a));
        }

        // DELETE: api/Areas/5
        //public void Delete(int id)
        //{
        //    areas aa = db.areas.FirstOrDefault(x => x.areaId == id);
        //    db.areas.Remove(aa);
        //    db.SaveChanges();
        //}
    }
}
