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
    internal class AppointmentsRepository : IAppointmentRepository
    {
        private readonly ApplicationContext _context;

        public AppointmentsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Appointment item)
        {
            _context.Appointments.Add(item.ToModel());
            return true;
        }

        public bool Delete(int id)
        {
            var app = GetItem(id);
            if (app == default)
                return false;

            _context.Appointments.Remove(app.ToModel());
            return true;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.Select(a => a.ToDomain());
        }

        public IEnumerable<DateTime> GetFreeTime(int doctorId)
        {
            var doc = _context.Doctors.Where(d => d.Id == doctorId);
            return _context.Appointments.Where(a => doc.Any()).Select(a => a.End);
        }

        public IEnumerable<DateTime> GetFreeTime(Spec spec)
        {
            var docs = _context.Doctors.Where(d => d.Spec == spec.ToModel());
            return _context.Appointments.Where(a => docs.Any(d => d.Id == a.DoctorId)).Select(a => a.End);
        }

        public Appointment? GetItem(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.Id == id)?.ToDomain();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Appointment item)
        {
            _context.Appointments.Update(item.ToModel());
            return true;
        }
    }
}