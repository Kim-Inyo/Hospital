using Domain.UseCase;
using Domain.Models;
using Domain.Logic;
using HospitalProjectIT.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Logic;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _service;
        private readonly DoctorService _serviceDoc;
        public ScheduleController(ScheduleService service, DoctorService doctorService)
        {
            _service = service;
            _serviceDoc = doctorService;
        }

        [HttpGet("get")]
        public IActionResult GetSchedule(int doctor_id)
        {
            var doc = _serviceDoc.FindDoctor(doctor_id);
            if (doc.IsFailure)
                return Problem(statusCode: 404, detail: doc.Error);

            var res = _service.GetScheduleOfDoctor(doctor_id);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(res.Value);
        }

        [Authorize]
        [HttpPost("register")]
        public IActionResult AddSchedule(int doctor_id, DateTime start_time, DateTime end_time)
        {
            Schedule schedule = new(0, doctor_id, start_time, end_time);

            var res = _service.AddSchedule(schedule);

            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok();
        }

        [Authorize]
        [HttpGet("update")]
        public IActionResult UpdateSchedule(int schedule_id, int? doctor_id, DateTime? start_time, DateTime? end_time)
        {
            var res = _service.GetSchedule(schedule_id);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            var schedule = res.Value;

            if (doctor_id != null)
                schedule.DoctorId = (int)doctor_id;
            if (start_time != null && end_time != null)
            {
                schedule.Start = (DateTime)start_time;
                schedule.End = (DateTime)end_time;
            }

            var res1 = _service.EditSchedule(schedule);

            if (res1.IsFailure)
                return Problem(statusCode: 404, detail: res1.Error);

            return Ok();
        }
    }
}