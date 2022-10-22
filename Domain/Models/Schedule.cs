using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Logic;

namespace Domain.Models
{
    public class Schedule
    {
        public int DoctorId = 0;
        public DateTime Start = DateTime.MinValue;
        public DateTime End = DateTime.MaxValue;

        public Schedule (int doctorId, DateTime start, DateTime end)
        {
            DoctorId = doctorId;
            Start = start;
            End = end;
        }

        public Result IsValid()
        {
            if (DoctorId < 0)
                return Result.Fail("Invalid doctor id");

            if (Start > End)
                return Result.Fail("Invalid time");

            return Result.Ok();
        }
    }
}
