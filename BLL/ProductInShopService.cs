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
        public List<ProductInShopDTO> Get(int shopId, int categoryId)
        {
            List<ProductInShopDTO> productInShop;
            using (dbprojectEntities db = new dbprojectEntities())
            {
                productInShop = Convertion.ProductInShopConvertion.Convert(db.productInShops.Where(x => x.ShopId == shopId && x.product.CategoryId == categoryId).ToList());
            }
            return productInShop;
        }

        // POST: api/Areas
        public ProductInShopDTO Post(ProductDTO p)
        {
            productInShop productInShop = new productInShop();
            productInShop.product = new product();
            using (dbprojectEntities db = new dbprojectEntities())
            {
                if (db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.shopId) != null)
                {
                    //איך אפשר לקצר?
                    db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.shopId).Price = p.Price;
                    db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.shopId).product.ProdDate = p.ProdDate;
                    db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.shopId).product.Name = p.Name;
                    db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.shopId).product.Picture = p.Picture;
                    db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.shopId).product.Description = p.Description;
                }
                productInShop.Price = p.Price;
                productInShop.product.ProdDate = p.ProdDate;
                productInShop.product.Name = p.Name;
                productInShop.product.Picture = p.Picture;
                productInShop.product.Description = p.Description;
                productInShop.product.Id = p.Id;
                productInShop.Productld = p.Id;
                productInShop.ShopId = p.shopId;
                db.productInShops.Add(productInShop);
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
