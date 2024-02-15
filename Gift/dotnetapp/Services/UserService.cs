// using dotnetapp.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using dotnetapp.Data;
// namespace dotnetapp.Services
// {
//     public class UserService : IUserService
//     {
//         private readonly UserManager<IdentityUser> _userManager;
//         private readonly SignInManager<IdentityUser> _signInManager;
//         private readonly IConfiguration _configuration;
//         private readonly ApplicationDbContext _context; // Add this field
 
 
//         public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, ApplicationDbContext context)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;
//             _configuration = configuration;
//             _context = context;
 
//         }
 
//         public async Task<bool> RegisterAsync(User user)
//         {
//             try
//             {
 
//                 var identityUser = new IdentityUser
//                 {
//                     UserName = user.Username,
//                 };
 
//                 Console.WriteLine(identityUser.UserName);
 
 
//                 var result = await _userManager.CreateAsync(identityUser, user.Password);
//                 Console.WriteLine("asd"+result);
 
//                 if (result.Succeeded)
//                 {
//                     // Assign roles to the user
//                     if (user.Role == "admin")
//                     {
//                         Console.WriteLine("data " + identityUser);
//                         await _userManager.AddToRoleAsync(identityUser, "admin");
//                     }
//                     else if (user.Role == "customer")
//                     {
//                         Console.WriteLine("data1 " + identityUser);
 
//                         await _userManager.AddToRoleAsync(identityUser, "customer");
//                         Console.WriteLine("data2 " + identityUser);
 
//                     }
//                     return true;
//                 }
//                 return false;
//             }
//             catch (Exception)
//             {
//                 // Handle exceptions appropriately (e.g., logging)
//                 return false; // Registration failed
//             }
//         }


// public async Task<string> LoginAsync(string email, string password)
//         {
//              try
//     {
//         var user = await _userManager.FindByNameAsync(email);
//         Console.WriteLine("User: " + user?.Email); // Debug output
//         Console.WriteLine("Password: " + password); // Debug output
 
//         if (user == null || !(await _signInManager.CheckPasswordSignInAsync(user, password, false)).Succeeded)
//         {
//             Console.WriteLine("service");
//             Console.WriteLine("Invalid username or password"); // Debug output
//             return null; // Invalid username or password
//         }
 
//         // Generate a JWT token
//         var token = GenerateJwtToken(user);
//         Console.WriteLine("Token: " + token); // Debug output
 
//         return token;
//     }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("zxcvbnm" + ex.Message);
//                 // Handle exceptions appropriately (e.g., logging)
//                 return null; // Login failed
//             }
//         }

//     private string GenerateJwtToken(IdentityUser user)
// {
//     Console.WriteLine("User: " + user.Email);
 
//     var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//     var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
//     var claims = new List<Claim>
//     {
//         new Claim(ClaimTypes.Email, user.Email),
//     };
 
//     // Retrieve roles for the user
//     var roles = _userManager.GetRolesAsync(user).Result;
 
//     Console.WriteLine("Roles: " + string.Join(", ", roles));
 
//     foreach (var role in roles)
// {
//     var roleClaim = new Claim(ClaimTypes.Role, role);
//     Console.WriteLine($"Adding role claim: {roleClaim.Type} - {roleClaim.Value}");
//     claims.Add(roleClaim);
// }
 
//     var token = new JwtSecurityToken(
//         _configuration["Jwt:Issuer"],
//         _configuration["Jwt:Audience"],
//         claims,
//         expires: DateTime.Now.AddHours(2),
//         signingCredentials: credentials
//     );
//     Console.WriteLine("Token generated successfully: " + token);
 
//     return new JwtSecurityTokenHandler().WriteToken(token);
// }

//     }
// }


using dotnetapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnetapp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;

        }
        public async Task<(int, string)> Register(RegisterModel model, string role)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return (0, "User already exists");

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                // Name = model.Name
            };
            var createUserResult = await userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
                return (0, "User creation failed! Please check user details and try again.");

            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

            if (await roleManager.RoleExistsAsync(UserRoles.User))
                await userManager.AddToRoleAsync(user, role);

            return (1, "User created successfully!");
        }

        public async Task<(int, string)> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return (0, "Invalid username");
            if (!await userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Invalid password");

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            return (1, token);
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
 