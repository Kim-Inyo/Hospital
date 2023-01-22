using Domain.UseCase;
using Domain.Models;
using HospitalProjectIT.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("get_user")]
        public ActionResult<UserSearchView> GetUserByLogin(int id)
        {
            if (id == 0)
                return Problem(statusCode: 404, detail: "Invalid ID");

            var userRes = _service.GetUserByLogin(id);
            if (userRes.IsFailure)
                return Problem(statusCode: 404, detail: userRes.Error);

            return Ok(new UserSearchView
            {
                Id = userRes.Value.Id,
                Tel = userRes.Value.Tel,
                Name = userRes.Value.Name,
                Role = userRes.Value.Role,

                UserName = userRes.Value.UserName,
                Password = userRes.Value.Password
            });
        }

        [Authorize]
        [HttpPost("register")]
        public IActionResult RegisterUser(string username, string password, string tel, string name, Role role)
        {
            User user = new(0, name, tel, role, username, password);
            var register = _service.Register(user);

            if (register.IsFailure)
                return Problem(statusCode: 404, detail: register.Error);

            return Ok(register.Value);
        }

        [HttpGet("is_user")]
        public IActionResult IsExists(string name)
        {
            var res = _service.IsExists(name);

            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(res.Value);
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll().Value);
        }
    }
}