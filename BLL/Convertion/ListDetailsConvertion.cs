using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class ListDetailsConvertion
    {
        public static listDetail Convert(ListDetailsDTO listDetail)
        {
            if (listDetail == null)
                return null;
            return new listDetail()
            {
                Id = listDetail.Id,
                CategoryId = listDetail.CaterogyId,
                ListId = listDetail.ListId
            };
        }
        public static ListDetailsDTO Convert(listDetail listDetail)
        {
            if (listDetail == null)
                return null;
            return new ListDetailsDTO()
            {
                Id = listDetail.Id,
                CaterogyId = listDetail.CategoryId,
                ListId = listDetail.ListId
            };
        }
        public static List<listDetail> Convert(List<ListDetailsDTO> listDetail)
        {
            return listDetail.Select(x => Convert(x)).ToList();
        }
        public static List<ListDetailsDTO> Convert(List<listDetail> listDetail)
        {
            return listDetail.Select(x => Convert(x)).ToList();
        }
    }
}
