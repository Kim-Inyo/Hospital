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

        public Result<Appointment> SaveAppointment(DateTime st, DateTime ed, int docid, int patid)
        {
            Appointment appointment = new Appointment(st, ed, patid, docid);
            var result = appointment.IsValid();
            if (result.IsFailure)
                return Result.Fail<Appointment>("Failed to Save Appointment");
            return Result.Ok(appointment);
        }

        public Result<IEnumerable<DateTime>> GetFreeTime(Spec spec)
        {
            var result = spec.IsValid();
            if (result.IsFailure)
                return Result.Fail<IEnumerable<DateTime>>("Invalid Spec");
            return Result.Ok(_db.GetFreeTime(spec));
        }
    }
}
