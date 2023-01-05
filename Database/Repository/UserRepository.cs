using Database.Converters;
using Domain.Logic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(User item)
        {
            _context.Users.Add(item.ToModel());
            return true;
        }

        public bool Delete(int id)
        {
            var user = GetItem(id);
            if (user == default)
                return false;

            _context.Users.Remove(user.ToModel());
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Select(u => u.ToDomain());
        }

        public User? GetItem(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user?.ToDomain();
        }

        public User? GetUserByLogin(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user?.ToDomain();
        }

        public bool IsExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(User item)
        {
            _context.Users.Update(item.ToModel());
            return true;
        }
    }
}