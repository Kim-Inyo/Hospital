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
