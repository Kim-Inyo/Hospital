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
        private readonly IAppointmentRepository _appdb;

        public DoctorService(IDoctorRepository db, IAppointmentRepository appdb)
        {
            _db = db;
            _appdb = appdb;
        }

        public Result<Doctor> CreateDoctor(Doctor doctor)
        {
            var result = doctor.IsValid();
            if (result.IsFailure)
                return Result.Fail<Doctor>("Invalid doctor: " + result.Error);

            var result1 = FindDoctor(doctor.Id);
            if (result1.Success)
                return Result.Fail<Doctor>("Doctor alredy exists");

            if (_db.Create(doctor))
            {
                _db.Save();
                return Result.Ok(doctor);
            }
            return Result.Fail<Doctor>("Unable to create doctor");
        }

        public Result<Doctor> DeleteDoctor(int id)
        {
            if (_appdb.GetFreeTime(id).Any())
                return Result.Fail<Doctor>("Unable to delete doctor: Doctor has appointments");

            var result = FindDoctor(id);
            if (result.IsFailure)
                return Result.Fail<Doctor>(result.Error);

            if (_db.Delete(id))
            {
                _db.Save();
                return result;
            }
            return Result.Fail<Doctor>("Unable to delete doctor");
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

        public Result<IEnumerable<Doctor>> GetAllDoctors()
        {
            return Result.Ok(_db.GetAll());
        }
    }
}
