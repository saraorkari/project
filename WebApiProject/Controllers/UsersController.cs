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

    public class UsersController : ApiController
    {
        UserService UserService = new UserService();
        //test
        // GET: api/Areas
        public List<UserDTO> Get()
        {

            return UserService.Get();
        }

        // GET: api/Areas/5
        public UserDTO Get(string name,string password)
        {
            return UserService.Get(name, password);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(UserDTO x)
        {
            if (x == null||x.Id=="5")
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
