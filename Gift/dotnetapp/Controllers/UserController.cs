using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.Extensions.Configuration;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult register([FromBody] User user)
        {
            var registeredUser = _userService.register(user);

            if (registeredUser != null)
            {
                var token = _userService.GenerateJwtToken(registeredUser);
                return CreatedAtAction(nameof(login), new { email = registeredUser.Email, token });
            }

            return Conflict(new { Message = "Email already registered." });
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] User user)
        {
            var authenticatedUser = _userService.login(user);

            if (authenticatedUser != null)
            {
                var token = _userService.GenerateJwtToken(authenticatedUser);
                return Ok(new { Message = "User login successful.", User = authenticatedUser, Token = token });
            }
            else
            {
                return NotFound(new { Message = "Invalid email or password." });
            }
        }
    }
}
