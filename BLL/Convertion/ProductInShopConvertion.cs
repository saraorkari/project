using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class ProductInShopConvertion
    {
        public static productInShop Convert(ProductInShopDTO productInShop)
        {
            if (productInShop == null)
                return null;
            return new productInShop()
            {
                Id = productInShop.Id,
                Price = productInShop.Price,
                Productld = productInShop.Productld,
                ShopId = productInShop.ShopId,
                Describe=productInShop.Description
            };
        }
        public static ProductInShopDTO Convert(productInShop productInShop)
        {
            if (productInShop == null)
                return null;
            return new ProductInShopDTO()
            {
                Id = productInShop.Id,
                Price = productInShop.Price,
                Productld = productInShop.Productld,
                Description=productInShop.Describe,
                ShopId = productInShop.ShopId,
                Product=ProductConvertion.Convert(productInShop.product),
                Shop=ShopConvertion.Convert(productInShop.shop)
            };
        }
        public static List<productInShop> Convert(List<ProductInShopDTO> productInShop)
        {
            return productInShop.Select(x => Convert(x)).ToList();
        }
        public static List<ProductInShopDTO> Convert(List<productInShop> productInShop)
        {
            return productInShop.Select(x => Convert(x)).ToList();
        }
    }
}
