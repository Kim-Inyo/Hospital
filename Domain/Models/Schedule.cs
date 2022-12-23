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
        public int Id { get; set; }
        public int DoctorId = 0;
        public DateTime Start;
        public DateTime End;

        public Schedule() : this(0, 0, DateTime.MinValue, DateTime.MaxValue) { }
        public Schedule (int id, int doctorId, DateTime start, DateTime end)
        {
            Id = id;
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
