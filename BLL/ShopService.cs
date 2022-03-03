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
        UserService UserService = new UserService();
        public List<ShopDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.ShopConvertion.Convert(db.shops.ToList());
            }
        }

        // GET: api/Areas/5
        public ShopDTO Get(int Id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.ShopConvertion.Convert(db.shops.FirstOrDefault(x => x.Id == Id));
            }
            return null;
        }
        public ShopDTO Get(string Name, string Password)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                shop shop = db.shops.FirstOrDefault(x => (x.Name == Name) && x.Password == Password);
                return Convertion.ShopConvertion.Convert(shop);
            }
        }
        public bool IsPassExit(string pass)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return db.shops.Any(x => x.Password == pass);
            }
        }
        public string Pass()
        {
            StringBuilder builder = new StringBuilder();
            Random rand;
            while (!IsPassExit(builder.ToString()) && builder.Length < 4)
            {
                rand = new Random();
                char ch = (char)rand.Next(23, 126);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        // POST: api/Areas
        public ShopDTO Post(ShopDTO u, ref string Mass)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                if (IsPassExit(u.Password))
                {
                    string pass = Pass();
                    Mass = " סיסמא קיימת החלף סיסמא - תוכל להשתמש בסיסמא" + pass + " ";
                    return null;
                }
                u.CityId = db.cities.FirstOrDefault(x => x.Name == u.CityName) == null?1:db.cities.FirstOrDefault(x => x.Name == u.CityName).Id;

                shop shop = db.shops.Add(Convertion.ShopConvertion.Convert(u));
                db.SaveChanges();
                return Convertion.ShopConvertion.Convert(shop);
            }
        }

        // PUT: api/Areas/5
        public ShopDTO Put(int id, ShopDTO s)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                //shop ss = db.shops.FirstOrDefault(x => x.Id == id);
                //if (ss != null)
                //{
                //    ss.Name = s.Name;
                //    ss.CityId = s.CityId;
                //    ss.Phone = s.Phone;
                //    db.SaveChanges();
                //    return Convertion.ShopConvertion.Convert(ss);
                //}
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
