using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class ProductInShopService
    {
        public List<ProductInShopDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.ProductInShopConvertion.Convert(db.productInShops.ToList());
            }
        }

        // GET: api/Areas/5
        public ProductInShopDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.ProductInShopConvertion.Convert(db.productInShops.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }

        // POST: api/Areas
        public ProductInShopDTO Post(ProductInShopDTO p)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                productInShop productInShop = db.productInShops.Add(Convertion.ProductInShopConvertion.Convert(p));
                db.SaveChanges();
                return Convertion.ProductInShopConvertion.Convert(productInShop);
            }
        }

        // PUT: api/Areas/5
        public ProductInShopDTO Put(int id, ProductInShopDTO p)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                productInShop ps = db.productInShops.FirstOrDefault(x => x.Id == id);
                if (ps != null)
                {
                    ps.Price = p.Price;
                    ps.Productld = p.Productld;
                    ps.ShopId = p.ShopId;
                    db.SaveChanges();
                    return Convertion.ProductInShopConvertion.Convert(ps);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                productInShop p = db.productInShops.FirstOrDefault(x => x.Id == id);
                db.productInShops.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
