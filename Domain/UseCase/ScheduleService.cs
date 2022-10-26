using Domain.Logic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class ScheduleService
    {
        public readonly IScheduleRepository _db;

        public ScheduleService (IScheduleRepository db)
        {
            _db = db;
        }

        public Result<Schedule> GetScheduleOfDoctor(int doctorid)
        {
            if (doctorid < 0)
                return Result.Fail<Schedule>("Invalid Doctor Id");
            Schedule schedule = _db.GetScheduleOfDoctor(doctorid);
            if (schedule != null)
                return Result.Ok(schedule);
            return Result.Fail<Schedule>("Schedule Not Found");
        }
        public Result AddSchedule(int doctorid, DateTime st, DateTime ed)
        {
            Schedule schedule = new Schedule(doctorid, st, ed);
            var result = schedule.IsValid();
            if (result.IsFailure)
                return Result.Fail("Invalid Schedule");
            _db.AddSchedule(doctorid, st, ed);
            return Result.Ok();
        }
        public Result EditSchedule(int doctorid, DateTime st, DateTime ed)
        {
            Schedule schedule = new Schedule(doctorid, st, ed);
            var result = schedule.IsValid();
            if (result.IsFailure)
                return Result.Fail("Invalid Schedule");
            if (doctorid < 0)
                return Result.Fail("Invalid Doctor Id");
            _db.EditSchedule(doctorid, st, ed);
            return Result.Ok();
        }
    }
}
