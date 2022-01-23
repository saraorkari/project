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
                user user = db.users.FirstOrDefault(x => (x.Id == userName || x.Email == userName) && x.Password == pass);
                if (user != null && user.Active == false)
                {
                    user.Active = true;
                }
                return Convertion.UsersConvertion.Convert(user);
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
        public bool IsIdExit(string Id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return db.users.Any(x => x.Id == Id);
            }
        }
        public bool IsPassExit(string pass)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return db.users.Any(x => x.Password == pass);
            }
        }
        public bool IsEmailExit(string Email)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return db.users.Any(x => x.Email == Email);
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


        public UserDTO Post(UserDTO u, ref string Mass)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                if (IsIdExit(u.Id))
                {
                    Mass = "תעודת זהות שמורה במערכת נא שחזר סיסמא";
                    return null;
                }
                if (IsEmailExit(u.Email))
                {
                    Mass = "מייל זה קיים במערכת";
                    return null;
                }
                if (IsPassExit(u.Password))
                {
                    string pass = Pass();
                    Mass = " סיסמא קיימת החלף סיסמא - תוכל להשתמש בסיסמא" + pass + " ";
                    return null;
                }
                u.Active = true;
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
                UserDTO user = Convertion.UsersConvertion.Convert(db.users.FirstOrDefault(x => x.Id == id));
                user.Active = false; 
            }
        }
        public void Delete(UserDTO u)
        {
            u.Active = false;
        }
    }
}
