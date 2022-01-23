﻿using System;
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
                if (shopId == -1) return Convertion.ProductInShopConvertion.Convert(db.productInShops.Where(x => x.product.CategoryId == categoryId).ToList());
                productInShop = Convertion.ProductInShopConvertion.Convert(db.productInShops.Where(x => x.ShopId == shopId && x.product.CategoryId == categoryId).ToList());
            }
            return productInShop;
        }

        // POST: api/Areas
        public ProductInShopDTO Post(ProductDTO p)
        {
            productInShop productInShop;
            MailService mailService = new MailService();
            string errMsg;
            using (dbprojectEntities db = new dbprojectEntities())
            {
                productInShop = db.productInShops.FirstOrDefault(x => x.Productld == p.Id && x.ShopId == p.shopId);
                if (productInShop != null)
                {
                    if (productInShop.Price > p.Price)
                    {
                        db.askUpdates.Where(x => x.user.Active == true && x.user.IsUpdate == true ? mailService.SendMail("update", x.UserId, x.product.Name, out errMsg):true);
                    }
                    productInShop.Price = p.Price;
                    productInShop.product.Name = p.Name;
                    productInShop.product.CategoryId = p.CategoryId;
                    productInShop.ProdDate = p.ProdDate;
                    productInShop.product.Picture = p.Picture;
                    productInShop.product.Description = p.Description;
                }
                else
                {
                    productInShop = new productInShop()
                    {
                        Price = p.Price,
                        ShopId = p.shopId,
                        ProdDate = p.ProdDate,
                        Productld = p.Id,
                        product = db.products.FirstOrDefault(x => x.Id == p.Id)
                    };
                    productInShop.product.CategoryId = p.CategoryId;
                    productInShop.product.Name = p.Name;
                    productInShop.product.Picture = p.Picture;
                    productInShop.product.Description = p.Description;
                    db.productInShops.Add(productInShop);
                }
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
