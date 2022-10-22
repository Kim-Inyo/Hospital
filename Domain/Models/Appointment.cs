using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Logic;

namespace Domain.Models
{
    public class Appointment
    {
        public DateTime Start = DateTime.MinValue;
        public DateTime End = DateTime.MaxValue;
        public int PatientId = 0;
        public int DoctorId = 0;

        public Appointment(DateTime start, DateTime end, int patientId, int doctorId)
        {
            Start = start;
            End = end;
            PatientId = patientId;
            DoctorId = doctorId;
        }

        public Result IsValid()
        {
            if (Start > End)
                return Result.Fail("Invalid Time");

            if (PatientId < 0)
                return Result.Fail("Invalid Patient Id");

            if (DoctorId < 0)
                return Result.Fail("Invalid Doctor Id");

            return Result.Ok();
        }
    }
}
