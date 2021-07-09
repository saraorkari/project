﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class ListDetailsService
    {
        public List<ListDetailsDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.ListDetailsConvertion.Convert(db.listDetails.ToList());
            }
        }

        // GET: api/Areas/5
        public ListDetailsDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.ListDetailsConvertion.Convert(db.listDetails.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public ListDetailsDTO Post(ListDetailsDTO l)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                listDetail listDetail = db.listDetails.Add(Convertion.ListDetailsConvertion.Convert(l));
                db.SaveChanges();
                return Convertion.ListDetailsConvertion.Convert(listDetail);
            }
        }

        // PUT: api/Areas/5
        public ListDetailsDTO Put(int id, ListDetailsDTO l)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                listDetail ld = db.listDetails.FirstOrDefault(x => x.Id == id);
                if (ld != null)
                {
                    ld.Productld = l.Productld;
                    ld.ListId = l.ListId;
                    db.SaveChanges();
                    return Convertion.ListDetailsConvertion.Convert(ld);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                listDetail l = db.listDetails.FirstOrDefault(x => x.Id == id);
                db.listDetails.Remove(l);
                db.SaveChanges();
            }
        }
    }
}
