using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class UserService
    {
        public List<UserDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.UsersConvertion.Convert(db.users.ToList());
            }
        }

        // GET: api/Areas/5
        public UserDTO Get(string pass, string userName)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.UsersConvertion.Convert(db.users.FirstOrDefault(x => (x.Id == userName || x.Email == userName) && x.Password == pass));
            }
        }

        // GET: api/Areas/5
        public UserDTO Get(string id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.UsersConvertion.Convert(db.users.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }
        public bool IsIdExti(string Id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return db.users.Any(x => x.Id == Id);
            }
        }
        public bool IsEmailExti(string Email)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return db.users.Any(x => x.Email == Email);
            }
        }
        // POST: api/Areas
        public UserDTO Post(UserDTO u, ref string Mass)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                if (IsIdExti(u.Id))
                {
                    Mass = "תעודת זהות שמורה במערכת נא שחזר סיסמא";
                    return null;
                }
                user user = db.users.Add(Convertion.UsersConvertion.Convert(u));
                db.SaveChanges();
                return Convertion.UsersConvertion.Convert(user);
            }
        }

        // PUT: api/Areas/5
        public UserDTO Put(string id, UserDTO u)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                user uu = db.users.FirstOrDefault(x => x.Id == id);
                if (uu != null)
                {
                    uu.Name = u.Name;
                    uu.Password = u.Password;
                    uu.Phon = u.Phon;
                    db.SaveChanges();
                    return Convertion.UsersConvertion.Convert(uu);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(string id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                user u = db.users.FirstOrDefault(x => x.Id == id);
                db.users.Remove(u);
                db.SaveChanges();
            }
        }
    }
}
