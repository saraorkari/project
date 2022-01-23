using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DTO
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string UserId { get; set; }
        public bool SendMail { get; set; }


    }
}