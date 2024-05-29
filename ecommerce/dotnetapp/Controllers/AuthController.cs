using dotnetapp.Data;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _userService = userService;
            _context = context;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("/auth/register")]
public async Task<IActionResult> Register([FromBody] User user)
{
    if (user == null)
    {
        Console.WriteLine("Invalid user data");
        return BadRequest("Invalid user data");
    }

    // Ensure that the provided role exists in the system
    var roleExists = await _roleManager.RoleExistsAsync(user.UserRole.ToUpper());
    if (!roleExists)
    {
        Console.WriteLine("Role does not exist");
        return BadRequest("Role does not exist");
    }

    // Check if the user already exists
    var userExists = await _userManager.FindByEmailAsync(user.EmailID);
    if (userExists != null)
    {
        Console.WriteLine("User with that email already exists");
        return BadRequest("User with that email already exists");
    }

    var identityUser = new IdentityUser
    {
        UserName = user.UserName,
        Email = user.EmailID
    };

    var result = await _userManager.CreateAsync(identityUser, user.Password);

    if (result.Succeeded)
    {
        await _userManager.AddToRoleAsync(identityUser, user.UserRole.ToUpper());
        Console.WriteLine($"Registration successful for user with email '{user.EmailID}' and role '{user.UserRole}'.");
        return Ok("Registration successful");
    }
    else
    {
        Console.WriteLine($"Registration failed for user with email '{user.EmailID}'. Errors:");
        foreach (var error in result.Errors)
        {
            Console.WriteLine($"- {error.Description}");
        }
        return StatusCode(500, "Registration failed");
    }
}


        [HttpPost("/auth/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.EmailID) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Invalid login request");

            var token = await _userService.LoginAsync(request.EmailID, request.Password);
            Console.WriteLine("Hello " + request.EmailID + " :" + request.Password);

            if (token == null)
                return Unauthorized("Invalid email or password");

            var user = await _userManager.FindByEmailAsync(request.EmailID);

            if (user == null)
                return Unauthorized("User not found");

            var role = await _userManager.GetRolesAsync(user);

            if (role != null && role.Any())
            {
                return Ok(new
                {
                    Token = token,
                    Username = user.UserName,
                    Role = role[0].ToString(),
                    UserId = user.Id
                });
            }
            else
            {
                return Unauthorized("User has no roles assigned");
            }
        }

        [HttpGet("/api/user")]
        public async Task<IActionResult> GetRegisteredUsers()
        {
            var students = await _userManager.GetUsersInRoleAsync("STUDENT");

            if (students == null || !students.Any())
                return NotFound("No students found");

            var studentDetails = students.Select(student => new
            {
                UserName = student.UserName,
                Email = student.Email
            });

            return Ok(studentDetails);
        }
    }
}
