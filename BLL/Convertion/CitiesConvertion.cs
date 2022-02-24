using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class CitiesConvertion
    
        
    {
        public static city Convert(CityDTO city)
        {
            if (city == null)
                return null;
            return new city()
            {
                Id = city.Id,
                Name = city.Name,
            };
        }
        public static CityDTO Convert(city city)
        {
            if (city == null)
                return null;
            return new CityDTO()
            {
                Id = city.Id,
                Name = city.Name,
            };
        }
        public static List<city> Convert(List<CityDTO> city)
        {
            return city.Select(x => Convert(x)).ToList();
        }
        public static List<CityDTO> Convert(List<city> city)
        {
            return city.Select(x => Convert(x)).ToList();
        }
    }
}

