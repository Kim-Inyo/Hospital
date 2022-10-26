using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Logic;

namespace Domain.Models
{
    public class User
    {

        public int Id;
        public string Name;
        public string Tel;
        public Role Role;

        public User()
        {
            Id = 0;
            Name = "";
            Tel = "";
            Role = Role.Patient;
        }

        public User(int id, string name, string tel, Role role)
        {
            Name = name;
            Id = id;
            Tel = tel;
            Role = role;
        }

        public Result IsValid()
        {
            if (Id < 0)
                return Result.Fail("Invalid id");

            if (string.IsNullOrEmpty(Name))
                return Result.Fail("Invalid username");

            if (string.IsNullOrEmpty(Tel))
                return Result.Fail("Invalid phone number");

            return Result.Ok();
        }
    }
}
