using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class AreaService
    {
        public List<AreaDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.AreaConvertion.Convert( db.areas.ToList());
            }
        }

        // GET: api/Areas/5
        public AreaDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.AreaConvertion.Convert(db.areas.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public AreaDTO Post(AreaDTO a)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
             area area=   db.areas.Add(Convertion.AreaConvertion.Convert(a));
                db.SaveChanges();
                return Convertion.AreaConvertion.Convert(area);
            }
        }

        // PUT: api/Areas/5
        public AreaDTO Put(int id, AreaDTO a)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                area aa = db.areas.FirstOrDefault(x => x.Id == id);
                if (aa != null)
                {
                    aa. Name = a.Name;
                    db.SaveChanges();
                    return Convertion.AreaConvertion.Convert(aa);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                area aa = db.areas.FirstOrDefault(x => x.Id == id);
                db.areas.Remove(aa);
                db.SaveChanges();
            }
        }
    }
}
