using Domain.Models;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Converters
{
    public static class UserConverter
    {
        public static DUser ToModel(this User model)
        {
            return new DUser
            {
                Id = model.Id,
                Tel = model.Tel,
                Name = model.Name,
                Role = model.Role,
                UserName = model.UserName,
                Password = model.Password,
            };
        }
        public static User ToDomain(this DUser model)
        {
            return new User
            {
                Id = model.Id,
                Tel = model.Tel,
                Name = model.Name,
                Role = model.Role,
                UserName = model.UserName,
                Password = model.Password,
            };
        }
    }
}
