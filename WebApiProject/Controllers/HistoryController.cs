using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;

namespace WebApiProject.Controllers
{
    public class HistoryController : ApiController
    {
        HistoryService HistoryService = new HistoryService();

        // GET: api/Areas
        public List<HistoryDTO> Get()
        {
            return HistoryService.Get();
        }

        // GET: api/Areas/5
        public HistoryDTO Get(int id)
        {
            return HistoryService.Get(id);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(HistoryDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            if (x.Id == 0)
                return NotFound();
            return Ok(HistoryService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, HistoryDTO x)
        {
            return Ok(HistoryService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            HistoryService.Delete(id);
        }
    }
}
