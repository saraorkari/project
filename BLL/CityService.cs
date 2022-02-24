using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class CityService
    {
        public List<CityDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.CitiesConvertion.Convert(db.cities.ToList());
            }
        }

        // GET: api/Areas/5
        public CityDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.CitiesConvertion.Convert(db.cities.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public CityDTO Post(CityDTO c)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                city city = db.cities.Add(Convertion.CitiesConvertion.Convert(c));
                db.SaveChanges();
                return Convertion.CitiesConvertion.Convert(city);
            }
        }

        // PUT: api/Areas/5
        public CityDTO Put(int id, CityDTO c)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                city cc = db.cities.FirstOrDefault(x => x.Id == id);
                if (cc != null)
                {
                    cc.Name = c.Name;
                    db.SaveChanges();
                    return Convertion.CitiesConvertion.Convert(cc);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                city c = db.cities.FirstOrDefault(x => x.Id == id);
                db.cities.Remove(c);
                db.SaveChanges();
            }
        }
    }
}
