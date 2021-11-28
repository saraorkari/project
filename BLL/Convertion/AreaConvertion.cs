using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
  public  class AreaConvertion
    {

        public static area Convert(AreaDTO area)
        {
            if (area == null)
                return null;
            return new area()
            {
                Id = area.Id,
                Name = area.Name,
                //  cityes=CitiesConvertion.Convert(area.cityes)
            };
        }
        public static AreaDTO Convert(area area)
        {
            if (area == null)
                return null;
            return new AreaDTO()
            {
                Id = area.Id,
                Name = area.Name,
                // cityes = CitiesConvertion.Convert(area.cities.ToList())
            };
        }
        public static List<area> Convert(List<AreaDTO> area)
        {
            return area.Select(x => Convert(x)).ToList();
        }
        public static List<AreaDTO> Convert(List<area> area)
        {
            return area.Select(x => Convert(x)).ToList();
        }
    }
}
