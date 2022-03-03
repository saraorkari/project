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
        public List<ProductInShopDTO> Get(int shopId)
        {
            //List<ProductInShopDTO> productInShop;
            using (dbprojectEntities db = new dbprojectEntities())
            {
                 return Convertion.ProductInShopConvertion.Convert(db.productInShops.Where(x=>x.ShopId==shopId).ToList());
                //productInShop = Convertion.ProductInShopConvertion.Convert(db.productInShops.Where(x => x.ShopId == shopId && x.product.CategoryId == categoryId).ToList());
            }
            //productInShop.GroupBy(x=>x.Productld);
            //return productInShop;
        }

        // POST: api/Areas
        public ProductInShopDTO Post(ProductInShopDTO    p)
        {
            productInShop productInShop;
            MailService mailService = new MailService();
            string errMsg;
            using (dbprojectEntities db = new dbprojectEntities())
            {
                productInShop = db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.ShopId);
                if (productInShop != null)
                {
                    productInShop.Price = p.Price;
                    productInShop.Describe = p.Description;
                    db.SaveChanges();

                }
                else
                {
                    productInShop = new productInShop()
                    {
                        Price = p.Price,
                        ShopId = p.ShopId,
                        Productld = p.Id,
                        Describe=p.Description
                    };
                    productInShop= db.productInShops.Add(productInShop);
                     db.SaveChanges();
                    productInShop = db.productInShops.Include("product").Include("shop").FirstOrDefault(x => x.Id == productInShop.Id);
                } 
               
                
               

                if (db.productInShops.Where(x=>x.Productld==p.Id).Min(x=>x.Price)==p.Price)
                {
                        var f = db.askUpdates.Where(x => x.ProductId == p.Id && x.user.Active == true && x.user.IsUpdate == true).ToList();
                        string subject = "עדכון על ירידת מחיר";
                    f.ForEach(x =>
                    {
                        //string body =  mailService.ReadFile(@"./html/update.html");
                        string body = mailService.ReadFile(@"C:/sara or/פרויקט גמר עם שרה אור/github/project/WebApiProject/mail/update.txt");

                        body = body.Replace("{productName}", productInShop.product.Name);
                        string shopDetails = "<b> שם: </b>" + productInShop.shop.Name + "<b> מספר טלפון: </b>" + productInShop.shop.Phone +
                        "<b> עיר: </b>" + productInShop.shop.city.Name;
                        string productDetails = "<b> שם: </b>" + productInShop.product.Name + "<b> תיאור: </b>" + p.Description + "<b> מחיר: </b>" + p.Price;
                        body = body.Replace("{shopDetails}", shopDetails);
                        body = body.Replace("{productDetails}", productDetails);
                        mailService.send(x.user.Email, body, subject, "saraor1412@gmail.com", out errMsg);
                    });

                }
               
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
