using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class CatogoryService
    {
        public List<CategoryDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.CategoryConvertion.Convert(db.categories.ToList());
            }
        }

        // GET: api/Areas/5
        public CategoryDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.CategoryConvertion.Convert(db.categories.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public CategoryDTO Post(CategoryDTO c)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                category category = db.categories.Add(Convertion.CategoryConvertion.Convert(c));
                db.SaveChanges();
                return Convertion.CategoryConvertion.Convert(category);
            }
        }

        // PUT: api/Areas/5
        public CategoryDTO Put(int id, CategoryDTO c)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                category cc = db.categories.FirstOrDefault(x => x.Id == id);
                if (cc != null)
                {
                    cc.Name = c.Name;
                    db.SaveChanges();
                    return Convertion.CategoryConvertion.Convert(cc);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                category c = db.categories.FirstOrDefault(x => x.Id == id);
                db.categories.Remove(c);
                db.SaveChanges();
            }
        }
    }
}
