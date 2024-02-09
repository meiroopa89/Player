// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            var registeredUser = _userService.RegisterUser(user);

            if (registeredUser != null)
            {
                return CreatedAtAction(nameof(LoginUser), new { email = registeredUser.Email }, registeredUser);
            }

            return Conflict(new { Message = "Email already registered." });
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] User user)
        {
            var authenticatedUser = _userService.LoginUser(user);

            if (authenticatedUser != null)
            {
                return Ok(authenticatedUser);
            }

            return NotFound(new { Message = "Invalid email or password." });
        }
    }
}
