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

        public Result<Doctor> AddDoctor(int id, string name, Spec spec)
        {
            Doctor doctor = new Doctor(id, name, spec);
            var result = doctor.IsValid();
            if (result.IsFailure)
                return Result.Fail<Doctor>("Invalid Doctor");
            if (_db.IsExists(id))
                return Result.Fail<Doctor>("Doctor Exists");
            _db.AddDoctor(id, name, spec);
            return Result.Ok(doctor);
        }

        public Result<bool> RemoveDoctor(int id)
        {
            if (id < 0)
                return Result.Fail<bool>("Invalid Id");
            if (!_db.IsExists(id))
                return Result.Fail<bool>("Doctor not Exists");
            if (_db.RemoveDoctor(id) != null);
                return Result.Ok(true);
            return Result.Fail<bool>("Failed to remove doctor");
        }

        public Result<IEnumerable<Doctor>> GetDoctorList()
        {
            return Result.Ok(_db.GetDoctorList());
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

        public Result<Doctor> FindDoctor(Spec spec)
        {
            var result = spec.IsValid();
            if (result.IsFailure)
                return Result.Fail<Doctor>("Invalid Spec");
            var doctor = _db.FindDoctor(spec);
            if (doctor != null)
                return Result.Ok(doctor);
            return Result.Fail<Doctor>("Doctor not found");
        }
    }
}
