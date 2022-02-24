using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class ProductWhithShop : ProductDTO
    {
        public List<ProductInShopDTO> ProductInShops { get; set; }
    }
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public double Price { get; set; }
        public int shopId { get; set; }
    }
}