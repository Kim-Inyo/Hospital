using Domain.Logic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Domain.UseCase
{
    public class DoctorService
    {
        public readonly IDoctorRepository _db;

        public DoctorService (IDoctorRepository db)
        {
            _db = db;
        }

        public Result<Doctor> FindDoctor(int id)
        {
            if (id < 0)
                return Result.Fail<Doctor>("Invalid Id");
            var doctor = _db.FindDoctor(id);
            if (doctor != null)
                return Result.Ok(doctor);
            return Result.Fail<Doctor>("Doctor not found");
        }

        public Result<IEnumerable<Doctor>> FindDoctor(Spec spec)
        {
            var result = spec.IsValid();
            if (result.IsFailure)
                return Result.Fail<IEnumerable<Doctor>>("Invalid Spec");
            var doctor = _db.FindDoctor(spec);
            if (doctor != null)
                return Result.Ok(doctor);
            return Result.Fail<IEnumerable<Doctor>>("Doctor not found");
        }
    }
}
