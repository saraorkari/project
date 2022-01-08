using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    class UsersConvertion
    {
        public static user Convert(UserDTO user)
        {
            if (user == null)
                return null;
            return new user()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Phon = user.Phon,
                Email = user.Email,
                AddressId = user.AreaId,
                Active= user.Active,
                IsUpdate=user.IsUpdate
            };
        }
        public static UserDTO Convert(user user)
        {
            if (user == null)
                return null;
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Phon = user.Phon,
                Email = user.Email,
                AreaId = user.AddressId,
                Active = user.Active,
                IsUpdate = user.IsUpdate
            };
        }
        public static List<user> Convert(List<UserDTO> user)
        {
            return user.Select(x => Convert(x)).ToList();
        }
        public static List<UserDTO> Convert(List<user> user)
        {
            return user.Select(x => Convert(x)).ToList();
        }
    }
}
