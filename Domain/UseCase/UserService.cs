using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Logic;

namespace Domain.UseCase
{
    public class UserService
    {
        public readonly IUserRepository _db;

        public UserService (IUserRepository userRepository)
        {
            _db = userRepository;
        }

        public Result<bool> IsExists(int id)
        {
            if (id < 0)
                return Result.Fail<bool>("Invalid Id");

            return Result.Ok(_db.IsExists(id));
        }
        public Result<User> AddUser(int id, string name, string tel, Role role)
        {
            User user = new User(id, name, tel, role);
            var result = user.IsValid();
            if (result.IsFailure)
                return Result.Fail<User>("Invalid User");
            if (_db.AddUser(name, tel, role) != null)
                return Result.Ok(user);
            return Result.Fail<User>("Failed to add user");
        }

        public Result<User> GetUserByLogin(int id)
        {
            if (id < 0)
                return Result.Fail<User>("Invalid Id");
            var user = _db.GetUserByLogin(id);
            if (user != null)
                return Result.Ok(user);
            return Result.Fail<User>("User Not Found");
        }
    }
}
