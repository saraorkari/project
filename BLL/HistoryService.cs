﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class HistoryService
    {
        public List<HistoryDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.HistoryConvertion.Convert(db.histories.ToList());
            }
        }

        // GET: api/Areas/5
        public HistoryDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.HistoryConvertion.Convert(db.histories.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public HistoryDTO Post(HistoryDTO h)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                history history = db.histories.Add(Convertion.HistoryConvertion.Convert(h));
                db.SaveChanges();
                return Convertion.HistoryConvertion.Convert(history);
            }
        }

        // PUT: api/Areas/5
        public HistoryDTO Put(int id, HistoryDTO h)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                history hh = db.histories.FirstOrDefault(x => x.Id == id);
                if (hh != null)
                {
                    hh.Productld = h.Productld;
                    hh.UserId = h.UserId;
                    db.SaveChanges();
                    return Convertion.HistoryConvertion.Convert(hh);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                history h = db.histories.FirstOrDefault(x => x.Id == id);
                db.histories.Remove(h);
                db.SaveChanges();
            }
        }
    }
}