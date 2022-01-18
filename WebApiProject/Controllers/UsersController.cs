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
        public UserDTO Get(string id)
        {
            return UserService.Get(id);
        }
        public IHttpActionResult Get(string UserName, string pass)
        {
            UserDTO x = UserService.Get(pass, UserName);
            if (x != null)
                return Ok(x);
            return BadRequest();
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
            string mass = "";
            x = UserService.Post(x, ref mass);
            if (x != null)
                return Ok(x);
            return BadRequest(mass);
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
        public void Delete(UserDTO u)
        {
            UserService.Delete(u);
        }
    }
}
