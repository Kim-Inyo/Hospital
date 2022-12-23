using Domain.Models;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Converters
{
    public static class DoctorConverter
    {
        public static DDoctor ToModel(this Doctor model)
        {
            return new DDoctor
            {
                Id = model.Id,
                Name = model.Name,
                Spec = model.Spec.ToModel()
            };
        }

        public static Doctor ToDomain(this DDoctor model)
        {
            return new Doctor
            {
                Id = model.Id,
                Name = model.Name,
                Spec = model.Spec.ToDomain()
            };
        }
    }
}
