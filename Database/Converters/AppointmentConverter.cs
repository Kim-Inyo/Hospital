using Domain.Models;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Converters
{
    public static class DomainModelAppointmentConverter
    {
        public static DAppointment ToModel(this Appointment model)
        {
            return new DAppointment
            {
                Id = model.Id,
                Start = model.Start,
                End = model.End,
                PatientId = model.PatientId,
                DoctorId = model.DoctorId
            };
        }

        public static Appointment ToDomain(this DAppointment model)
        {
            return new Appointment
            {
                Id = model.Id,
                Start = model.Start,
                End = model.End,
                PatientId = model.PatientId,
                DoctorId = model.DoctorId
            };
        }
    }
}