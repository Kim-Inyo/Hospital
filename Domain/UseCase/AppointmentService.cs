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
            IEnumerable<FreeTime> FreeTime = _db.GetFreeTime(docid);
            FreeTime written = new FreeTime(st, ed);
            foreach(FreeTime dt in FreeTime)
            {
                if(dt.In(written))
                    return Result.Ok(appointment);
            }
            return Result.Fail<Appointment>("This time is busy");
        }

        public Result<IEnumerable<FreeTime>> GetFreeTime(Spec spec)
        {
            var result = spec.IsValid();
            if (result.IsFailure)
                return Result.Fail<IEnumerable<FreeTime>>("Invalid Spec");
            return Result.Ok(_db.GetFreeTime(spec));
        }

        public Result<IEnumerable<FreeTime>> GetFreeTime(int docid)
        {
            if (docid < 0)
                return Result.Fail<IEnumerable<FreeTime>>("Invalid Doctor ID");
            return Result.Ok(_db.GetFreeTime(docid));
        }
    }
}
