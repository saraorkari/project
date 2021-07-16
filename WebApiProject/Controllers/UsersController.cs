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
    public class UsersController : ApiController
    {
        UserService UserService = new UserService();

        // GET: api/Areas
        public List<UserDTO> Get()
        {
            return UserService.Get();
        }

        // GET: api/Areas/5
        public UserDTO Get(string id)
        {
            return UserService.Get(id);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(UserDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            if (x.Id == "")
                return NotFound();
            return Ok(UserService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(string id, UserDTO x)
        {
            return Ok(UserService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(string id)
        {
            UserService.Delete(id);
        }
    }
}
