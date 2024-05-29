using dotnetapp.Data;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService _userService;

        public AuthController(IUserService userService, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _userService = userService;
            _context = context;
        }

        [HttpPost("/auth/register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid user data");
                }

                var isRegistered = await _userService.RegisterAsync(user);

                if (isRegistered)
                {
                    // Return 200 OK with success message
                    return Ok("Registration successful");
                }
                else
                {
                    // Return 500 Internal Server Error with failure message
                    return StatusCode(500, "Registration failed. Email may already exist.");
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error during registration: {ex.Message}");
                return StatusCode(500, "An error occurred during registration");
            }
        }

        [HttpPost("/auth/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.EmailID) || string.IsNullOrWhiteSpace(request.Password))
                    return BadRequest("Invalid login request");

                var token = await _userService.LoginAsync(request.EmailID, request.Password);

                if (token == null)
                    return Unauthorized("Invalid email or password");

                var user = await _userManager.FindByEmailAsync(request.EmailID);

                if (user == null)
                    return Unauthorized("User not found");

                var roles = await _userManager.GetRolesAsync(user);

                return Ok(new
                {
                    Token = token,
                    Username = user.UserName,
                    Role = roles.FirstOrDefault(), // Use FirstOrDefault to safely access the first role
                    UserId = user.Id
                });
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error during login: {ex.Message}");
                return StatusCode(500, "An error occurred during login");
            }
        }

        [HttpGet("/api/user")]
        public async Task<IActionResult> GetRegisteredUsers()
        {
            try
            {
                var students = await _userManager.GetUsersInRoleAsync("USER");

                if (students == null || !students.Any())
                    return NotFound("No students found");

                var studentDetails = students.Select(student => new
                {
                    UserName = student.UserName,
                    Email = student.Email
                });

                return Ok(studentDetails);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error while fetching registered users: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching registered users");
            }
        }
    }
}
