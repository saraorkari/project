using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class HistoryConvertion
    {
        public static history Convert(HistoryDTO history)
        {
            if (history == null)
                return null;
            return new history()
            {
                Id = history.Id,
                ProductName = history.ProductName,
                UserId = history.UserId
            };
        }
        public static HistoryDTO Convert(history history)
        {
            if (history == null)
                return null;
            return new HistoryDTO()
            {
                Id = history.Id,
                ProductName = history.ProductName,
                UserId = history.UserId
            };
        }
        public static List<history> Convert(List<HistoryDTO> history)
        {
            return history.Select(x => Convert(x)).ToList();
        }
        public static List<HistoryDTO> Convert(List<history> history)
        {
            return history.Select(x => Convert(x)).ToList();
        }
    }
}
