// using dotnetapp.Models;
// using dotnetapp.Services;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using dotnetapp.Data;

// namespace dotnetapp.Controllers
// {
//     [Route("api/")]
//     [ApiController]
//     public class AuthController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;
//         private readonly UserManager<IdentityUser> _userManager;

//         private readonly IUserService _userService;

//         public AuthController(IUserService userService, ApplicationDbContext context, UserManager<IdentityUser> userManager)
//         {
//             _userManager = userManager;
//             _userService = userService;
//             _context = context;

//         }

//         [HttpPost("register")]
//         public async Task<IActionResult> Register([FromBody] User user)
//         {
//             if (user == null)
//                 return BadRequest("Invalid user data");

//             if (user.Role == "admin" || user.Role == "customer")
//             {
//                 Console.WriteLine("asd  "+user.Role);

//                 var isRegistered = await _userService.RegisterAsync(user);
//                 Console.WriteLine("status"+isRegistered);

//                 if (isRegistered)
//                 {
//                     var customUser = new User
//                     {
//                         Username = user.Username,
//                         Password = user.Password,
//                         Email = user.Email,
//                         MobileNumber = user.MobileNumber,
//                         Role = user.Role,
//                     };

//                     // Add the customUser to the DbSet and save it
//                     _context.Users.Add(customUser);
//                     await _context.SaveChangesAsync();

//                     return Ok(user);
//                 }
//             }

//             return BadRequest("Registration failed. Username may already exist.");
//         }


//         // [HttpPost("login")]
//         // public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
//         // {
//         //     if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
//         //         return BadRequest("Invalid login request");

//         //     var token = await _userService.LoginAsync(request.Username, request.Password);

//         //     if (token == null)
//         //         return Unauthorized("Invalid username or password");

//         //     // Retrieve the user from UserManager to get their roles
//         //     var user = await _userManager.FindByNameAsync(request.Username);
//         //     Console.WriteLine("role"+user);
//         //     var roles = await _userManager.GetRolesAsync(user);

//         //     return Ok(new { Token = token, Roles = roles });
//         // }

//         [HttpPost("login")]
// public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
// {
//     if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
//         return BadRequest("Invalid login request");

//     var token = await _userService.LoginAsync(request.Email, request.Password);

//     if (token == null)
//         return Unauthorized("Invalid email or password");

//     // Retrieve the user from UserManager to get their roles
//     var user = await _userManager.FindByEmailAsync(request.Email);
//     Console.WriteLine("role" + user);
//     var roles = await _userManager.GetRolesAsync(user);

//     return Ok(new { Token = token, Roles = roles });
// }

//     }
// }


using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using dotnetapp.Data;

namespace dotnetapp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
    //     private readonly ApplicationDbContext _context;
    //     private readonly UserManager<IdentityUser> _userManager;

    //     private readonly UserService _userService;

    //     public AuthController(UserService userService, ApplicationDbContext context, UserManager<IdentityUser> userManager)
    //     {
    //         _userManager = userManager;
    //         _userService = userService;
    //         _context = context;
    //     }

    //     [HttpPost("register")]
    //     public async Task<IActionResult> Register([FromBody] User user)
    //     {
    //         if (user == null)
    //             return BadRequest("Invalid user data");

    //         if (user.Role == "admin" || user.Role == "customer")
    //         {
    //             Console.WriteLine("asd  " + user.Role);

    //             var isRegistered = await _userService.RegisterAsync(user);
    //             Console.WriteLine("status" + isRegistered);

    //             if (isRegistered)
    //             {
    //                 var customUser = new User
    //                 {
    //                     Username = user.Username,
    //                     Password = user.Password,
    //                     Email = user.Email,
    //                     MobileNumber = user.MobileNumber,
    //                     Role = user.Role,
    //                 };

    //                 // Add the customUser to the DbSet and save it
    //                 _context.Users.Add(customUser);
    //                 await _context.SaveChangesAsync();

    //                 return Ok(user);
    //             }
    //         }

    //         return BadRequest("Registration failed. Username may already exist.");
    //     }

    //    [HttpPost("login")]
    //     public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    //     {
    //         if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
    //             return BadRequest("Invalid login request");
    //         Console.WriteLine("controller" + request.Email);
    //         var token = await _userService.LoginAsync(request.Email, request.Password);
 
    //         if (token == null)
    //             return Unauthorized("Invalid email or password");
 
    //         // Retrieve the user from UserManager to get their roles
    //         var user = await _userManager.FindByNameAsync(request.Email);
    //         Console.WriteLine("role"+user);
    //         var roles = await _userManager.GetRolesAsync(user);
 
    //         return Ok(new { Token = token, Roles = roles });
    //     }


    private readonly IUserService _authService;
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;

        public AuthController(IUserService authService, ILogger<AuthController> logger, ApplicationDbContext context)
        {
            _authService = authService;
            _logger = logger;
            _context = context;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.Login(model);
                if (status == 0)
                    return BadRequest(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("registeration")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                if (model.Role == "Admin" || model.Role == "User")
                {
                    var (status, message) = await _authService.Register(model, model.Role);
                    if (status == 0)
                    {
                        return BadRequest(message);
                    }
                    var user = new User
                    {
                        Username = model.Username,
                        Password = model.Password,
                        Email = model.Email,
                        Role = model.Role,
                    };
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    //return CreatedAtAction(nameof(Register), model);
                    return Ok(message);
                }
                else
                {
                    return BadRequest("Invalid Role");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}


