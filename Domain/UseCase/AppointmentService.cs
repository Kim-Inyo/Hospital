using Domain.Logic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class AppointmentService
    {
        public readonly IAppointmentRepository _db;

        public AppointmentService (IAppointmentRepository db)
        {
            _db = db;
        }

        public Result<Appointment> SaveAppointment(Appointment appointment, Schedule schedule)
        {
            var result = appointment.IsValid();
            if (result.IsFailure)
                return Result.Fail<Appointment>("Invalid appointment: " + result.Error);

            var result1 = schedule.IsValid();
            if (result1.IsFailure)
                return Result.Fail<Appointment>("Invalid schedule: " + result1.Error);

            if (schedule.Start > appointment.Start || schedule.End < appointment.End)
                return Result.Fail<Appointment>("Appointment out of schedule");

            var apps = _db.GetFreeTime(appointment.DoctorId);
            if (apps.Any(a => appointment.Start > a))
                return Result.Fail<Appointment>("Appointment time already taken");

            if (_db.Create(appointment))
            {
                _db.Save();
                return Result.Ok(appointment);
            }
            return Result.Fail<Appointment>("Unable to save appointment");
        }

        public Result<IEnumerable<DateTime>> GetFreeTime(Spec spec)
        {
            var result = spec.IsValid();
            if (result.IsFailure)
                return Result.Fail<IEnumerable<DateTime>>("Invalid Spec");
            return Result.Ok(_db.GetFreeTime(spec));
        }

        public Result<IEnumerable<DateTime>> GetFreeTime(int docid)
        {
            if (docid < 0)
                return Result.Fail<IEnumerable<DateTime>>("Invalid Doctor ID");
            return Result.Ok(_db.GetFreeTime(docid));
        }
    }
}
