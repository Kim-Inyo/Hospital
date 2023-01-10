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

        public Result<User> Register(User user)
        {
            var result = user.IsValid();
            if (result.IsFailure)
                return Result.Fail<User>("Invalid user: " + result.Error);

            if (_db.IsExists(user.Name))
                return Result.Fail<User>("Username already exists");

            if (_db.Create(user))
            {
                _db.Save();
                return Result.Ok(user);
            }
            return Result.Fail<User>("Unable to create user");
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

        public Result<bool> IsExists(string name)
        {
            if (name == String.Empty)
                return Result.Fail<bool>("Please fill your name");

            return Result.Ok(_db.IsExists(name));
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

        public Result<IEnumerable<User>> GetAll()
        {
            return Result.Ok(_db.GetAll());
        }
    }
}
