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
        public string UserName;
        public string Password;

        public User()
        {
            Id = 0;
            Name = "";
            Tel = "";
            Role = Role.Patient;
            UserName = "";
            Password = "";
        }

        public User(int id, string name, string tel, Role role, string username, string password)
        {
            Name = name;
            Id = id;
            Tel = tel;
            Role = role;
            UserName = username;
            Password = password;
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
