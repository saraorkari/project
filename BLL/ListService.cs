using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class ListService
    {
        public List<ListDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.ListsConvertion.Convert(db.lists.ToList());
            }
        }

        // GET: api/Areas/5
        public ListDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.ListsConvertion.Convert(db.lists.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public ListDTO Post(ListDTO l)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                list list = db.lists.Add(Convertion.ListsConvertion.Convert(l));
                db.SaveChanges();
                return Convertion.ListsConvertion.Convert(list);
            }
        }

        // PUT: api/Areas/5
        public ListDTO Put(int id, ListDTO l)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                list ll = db.lists.FirstOrDefault(x => x.Id == id);
                if (ll != null)
                {
                    ll.Name = l.Name;
                    db.SaveChanges();
                    return Convertion.ListsConvertion.Convert(ll);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                list l = db.lists.FirstOrDefault(x => x.Id == id);
                db.lists.Remove(l);
                db.SaveChanges();
            }
        }
    }
}
