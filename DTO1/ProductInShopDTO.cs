using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class ProductInShopDTO:IComparable
    {
        public int Id { get; set; }
        public int Productld { get; set; }
        public int ShopId { get; set; }
        public double Price { get; set; }
        public Nullable<System.DateTime> ProdDate { get; set; }
        public ProductDTO Product { get; set; }
        public ShopDTO Shop { get; set; }
        public int CompareTo(object obj)
        {
            if (obj is ProductInShopDTO)
            {
                return Productld - (obj as ProductInShopDTO).Productld;
            }
            return -1;
        }
    }
}