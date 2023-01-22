using Domain.UseCase;
using Domain.Models;
using Domain.Logic;
using HospitalProjectIT.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("Spec")]
    public class SpecController : ControllerBase
    {
        private readonly ISpecRepository _rep;
        public SpecController(ISpecRepository rep)
        {
            _rep = rep;
        }

        [Authorize]
        [HttpPost("add")]
        public IActionResult AddSpec(string name)
        {
            Spec Spec = new(0, name);
            var res = Spec.IsValid();
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            if (_rep.Create(Spec))
            {
                _rep.Save();
                return Ok(_rep.GetByName(name));
            }
            return Problem(statusCode: 404, detail: "Error while creating");
        }

        [Authorize]
        [HttpDelete("delete")]
        public IActionResult DeleteSpec(int id)
        {
            if (_rep.Delete(id))
            {
                _rep.Save();
                return Ok();
            }
            return Problem(statusCode: 404, detail: "Error while deleting");

        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            return Ok(_rep.GetAll());
        }
    }
}