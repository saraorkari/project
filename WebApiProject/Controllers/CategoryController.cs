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
    public class CategoryController : ApiController
    {
        CatogoryService CatogoryService = new CatogoryService();

        // GET: api/Areas
        public List<CategoryDTO> Get()
        {
            return CatogoryService.Get();
        }

        // GET: api/Areas/5
        public CategoryDTO Get(int id)
        {
            return CatogoryService.Get(id);
        }

        // POST: api/Areas
        [HttpPost]
        public IHttpActionResult Post(CategoryDTO x)
        {
            if (x == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            if (x.Id == 0)
                return NotFound();
            return Ok(CatogoryService.Post(x));
        }

        // PUT: api/Areas/5
        [HttpPut]
        public IHttpActionResult Put(int id, CategoryDTO x)
        {
            return Ok(CatogoryService.Put(id, x));
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            CatogoryService.Delete(id);
        }
    }
}
