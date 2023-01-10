using Domain.Logic;
using Domain.Models;
using Database.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class SpecRepository : IRepository<Spec>
    {
        private readonly ApplicationContext _context;

        public SpecRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Spec item)
        {
            _context.Specs.Add(item.ToModel());
            return true;
        }

        public bool Delete(int id)
        {
            var spec = GetItem(id);
            if (spec == default)
                return false;

            _context.Specs.Remove(spec.ToModel());
            return true;
        }

        public IEnumerable<Spec> GetAll()
        {
            return _context.Specs.Select(s => s.ToDomain());
        }

        public Spec? GetItem(int id)
        {
            return _context.Specs.FirstOrDefault(s => s.Id == id)?.ToDomain();
        }

        public Spec? GetById(int id)
        {
            return _context.Specs.FirstOrDefault(s => s.Id == id)?.ToDomain();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Spec item)
        {
            _context.Specs.Update(item.ToModel());
            return true;
        }
    }
}