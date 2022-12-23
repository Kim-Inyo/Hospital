using Domain.Models;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Converters
{
    public static class ScheduleConverter
    {
        public static DSchedule ToModel(this Schedule model)
        {
            return new DSchedule
            {
                Id = model.Id,
                Start = model.Start,
                End = model.End,
                DoctorId = model.DoctorId
            };
        }

        public static Schedule ToDomain(this DSchedule model)
        {
            return new Schedule
            {
                Id = model.Id,
                Start = model.Start,
                End = model.End,
                DoctorId = model.DoctorId
            };
        }
    }
}
