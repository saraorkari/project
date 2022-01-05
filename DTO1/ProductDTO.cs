using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ProdDate { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public double Price { get; set; }
        public int shopId { get; set; }
    }
}