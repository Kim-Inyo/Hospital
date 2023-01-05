using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public interface IUserRepository : IRepository<User>
    {
        public bool IsExists(int id);
        public User? AddUser(int id, string name, string tel, Role role);
        public User? GetUserByLogin(int id);
    }
}
