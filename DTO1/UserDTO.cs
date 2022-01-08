using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phon { get; set; }
        public int AreaId { get; set; }
        public bool? Active { get; set; }
        public bool? IsUpdate { get; set; }

     
    }
}