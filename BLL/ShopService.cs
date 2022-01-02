using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class ShopService
    {
        public List<ShopDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.ShopConvertion.Convert(db.shops.ToList());
            }
        }

        // GET: api/Areas/5
        public ShopDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.ShopConvertion.Convert(db.shops.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public ShopDTO Post(ShopDTO s, string cityName)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                s.CityId = db.cities.FirstOrDefault(x => x.Name == cityName).Id;
                shop shop = db.shops.Add(Convertion.ShopConvertion.Convert(s));
                db.SaveChanges();
                return Convertion.ShopConvertion.Convert(shop);
            }
        }

        // PUT: api/Areas/5
        public ShopDTO Put(int id, ShopDTO s)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                shop ss = db.shops.FirstOrDefault(x => x.Id == id);
                if (ss != null)
                {
                    ss.Name = s.Name;
                    ss.CityId = s.CityId;
                    ss.Phone = s.Phone;
                    db.SaveChanges();
                    return Convertion.ShopConvertion.Convert(ss);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                shop s = db.shops.FirstOrDefault(x => x.Id == id);
                db.shops.Remove(s);
                db.SaveChanges();
            }
        }
    }
}
