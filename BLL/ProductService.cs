using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class ProductService

    {
        public List<ProductDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.ProductConvertion.Convert(db.products.ToList());
            }
        }

        // GET: api/Areas/5

        //public List<ProductDTO> Get(int categoryId)
        //{
        //    using (dbprojectEntities db = new dbprojectEntities())
        //    {
        //        return Convertion.ProductConvertion.Convert(db.products.Where(x => x.CategoryId == categoryId).ToList());
        //    }
        //}
        public List<ProductWhithShop> Get(int categoryId)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                List<ProductWhithShop> shops= Convertion.ProductConvertion.Convert1(db.products.Where(x => x.CategoryId == categoryId).ToList()).OrderBy(x => x.Id).ToList();
                return shops;
            }
            
        }
        public List<ProductDTO> Get(string SearcText)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.ProductConvertion.Convert(db.products.Where(x => x.Name.Contains(SearcText)).ToList());
            }
            return null;
        }

        // POST: api/Areas
        public ProductDTO Post(ProductDTO p)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                product product = db.products.Add(Convertion.ProductConvertion.Convert(p));
                db.SaveChanges();
                return Convertion.ProductConvertion.Convert(product);
            }
        }

        // PUT: api/Areas/5
        public ProductDTO Put(int id, ProductDTO p)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                product ps = db.products.FirstOrDefault(x => x.Id == id);
                if (ps != null)
                {
                    ps.Name = p.Name;
                    ps.Picture = p.Picture;
                    ps.CategoryId = p.CategoryId;
                    db.SaveChanges();
                    return Convertion.ProductConvertion.Convert(ps);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                product p = db.products.FirstOrDefault(x => x.Id == id);
                db.products.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
