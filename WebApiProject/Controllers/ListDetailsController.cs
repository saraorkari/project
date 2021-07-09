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
    public class ListDetailsController : ApiController
    {
        ListDetailsService ListDetailsService = new ListDetailsService();

        // GET: api/Areas
        public List<ListDetailsDTO> Get()
        {
            return ListDetailsService.Get();
        }

        // GET: api/Areas/5
        public ListDetailsDTO Get(int id)
        {
            return ListDetailsService.Get(id);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(ListDetailsDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            if (x.Id == 0)
                return NotFound();
            return Ok(ListDetailsService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, ListDetailsDTO x)
        {
            return Ok(ListDetailsService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            ListDetailsService.Delete(id);
        }
    }
}
