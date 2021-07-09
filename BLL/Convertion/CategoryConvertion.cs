using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class CategoryConvertion
    {
        public static category Convert(CategoryDTO category)
        {
            if (category == null)
                return null;
            return new category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public static CategoryDTO Convert(category category)
        {
            if (category == null)
                return null;
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public static List<category> Convert(List<CategoryDTO> category)
        {
            return category.Select(x => Convert(x)).ToList();
        }
        public static List<CategoryDTO> Convert(List<category> category)
        {
            return category.Select(x => Convert(x)).ToList();
        }
    }
}

