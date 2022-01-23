using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class ProductConvertion
    {
        public static product Convert(ProductDTO product)
        {
            if (product == null)
                return null;
            return new product()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Picture = product.Picture,
                CategoryId = product.CategoryId
            };
        }
        public static ProductDTO Convert(product product)
        {
            if (product == null)
                return null;
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Picture = product.Picture,
                CategoryId = product.CategoryId
            };
        }
        public static List<product> Convert(List<ProductDTO> product)
        {
            return product.Select(x => Convert(x)).ToList();
        }
        public static List<ProductDTO> Convert(List<product> product)
        {
            return product.Select(x => Convert(x)).ToList();
        }
    }
}
