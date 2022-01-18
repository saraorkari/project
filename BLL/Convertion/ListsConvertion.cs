using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class ListsConvertion
    {
        public static list Convert(ListDTO list)
        {
            if (list == null)
                return null;
            return new list()
            {
                Id = list.Id,
                Name = list.Name,
                Picture=list.Picture
            };
        }
        public static ListDTO Convert(list list)
        {
            if (list == null)
                return null;
            return new ListDTO()
            {
                Id = list.Id,
                Name = list.Name,
                Picture=list.Picture
            };
        }
        public static List<list> Convert(List<ListDTO> list)
        {
            return list.Select(x => Convert(x)).ToList();
        }
        public static List<ListDTO> Convert(List<list> list)
        {
            return list.Select(x => Convert(x)).ToList();
        }
    }
}
