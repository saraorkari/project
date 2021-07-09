﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;

namespace WebApiProject.Controllers
{
    public class ListsController : ApiController
    {
        ListService ListService = new ListService();

        // GET: api/Areas
        public List<ListDTO> Get()
        {
            return ListService.Get();
        }

        // GET: api/Areas/5
        public ListDTO Get(int id)
        {
            return ListService.Get(id);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(ListDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            if (x.Id == 0)
                return NotFound();
            return Ok(ListService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, ListDTO x)
        {
            return Ok(ListService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            ListService.Delete(id);
        }
    }
}
