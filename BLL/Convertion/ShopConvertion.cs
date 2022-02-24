using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class ShopConvertion
    {
        public static shop Convert(ShopDTO shop)
        {
            if (shop == null)
                return null;
            return new shop()
            {
                Id = shop.Id,
                Name = shop.Name,
                CityId = shop.CityId,
                Phone=shop.Phone,
                Password=shop.Password
            };
        }
        public static ShopDTO Convert(shop shop)
        {
            if (shop == null)
                return null;
            return new ShopDTO()
            {
                Id = shop.Id,
                Name = shop.Name,
                CityId = shop.CityId,
                Phone = shop.Phone,
                CityName = shop.city?.Name,
                Password = shop.Password
            };
        }
        public static List<shop> Convert(List<ShopDTO> shop)
        {
            return shop.Select(x => Convert(x)).ToList();
        }
        public static List<ShopDTO> Convert(List<shop> shop)
        {
            return shop.Select(x => Convert(x)).ToList();
        }
    }
}
