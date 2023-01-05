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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationContext _context;

        public DoctorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Doctor item)
        {
            _context.Doctors.Add(item.ToModel());
            return true;
        }

        public bool Delete(int id)
        {
            var doctor = GetItem(id);
            if (doctor == default)
                return false;

            _context.Remove(doctor.ToModel());
            return true;
        }

        public Doctor? FindDoctor(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            return doctor?.ToDomain();
        }

        public IEnumerable<Doctor> FindDoctor(Spec spec)
        {
            return _context.Doctors.Where(d => d.Spec == spec.ToModel()).Select(d => d.ToDomain());
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.Select(d => d.ToDomain());
        }

        public Doctor? GetItem(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id)?.ToDomain();
        }

        public bool IsExists(int id)
        {
            return _context.Doctors.Any(d => d.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Doctor item)
        {
            _context.Doctors.Update(item.ToModel());
            return true;
        }
    }
}