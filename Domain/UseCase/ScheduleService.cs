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

        public Result<IEnumerable<Schedule>> GetScheduleOfDoctor(int doctorid)
        {
            if (doctorid < 0)
                return Result.Fail<IEnumerable<Schedule>>("Invalid Doctor Id");
            IEnumerable<Schedule> schedules = _db.GetScheduleOfDoctor(doctorid);
            if (schedules != null)
                return Result.Ok(schedules);
            return Result.Fail<IEnumerable<Schedule>>("Schedule Not Found");
        }

        public Result EditSchedule(Schedule schedule)
        {
            var result = schedule.IsValid();
            if (result.IsFailure)
                return Result.Fail("Invalid Schedule");
            if (schedule.DoctorId < 0)
                return Result.Fail("Invalid Doctor Id");
            _db.EditSchedule(schedule);
            return Result.Ok();
        }
    }
}
