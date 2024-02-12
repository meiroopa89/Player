// // Services/UserServiceImpl.cs
// using dotnetapp.Models;
// using dotnetapp.Repositories;

// namespace dotnetapp.Services
// {
//     public class UserServiceImpl : UserService
//     {
//         private readonly UserRepository _userRepository;

//         public UserServiceImpl(UserRepository userRepository)
//         {
//             _userRepository = userRepository;
//         }

//         public User register(User user)
//         {
//             return _userRepository.register(user);
//         }

//         public User login(User user)
//         {
//             return _userRepository.login(user);
//         }
//     }
// }

// Services/UserServiceImpl.cs
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using dotnetapp.Models;
using dotnetapp.Repositories;
using System.Security.Cryptography;

namespace dotnetapp.Services
{
    public class UserServiceImpl : UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserServiceImpl(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public User register(User user)
        {
            return _userRepository.register(user);
        }

        public User login(User user)
        {
            return _userRepository.login(user);
        }

        // public string GenerateJwtToken(User user)
        // {
        //     var tokenHandler = new JwtSecurityTokenHandler();

        //     using (var hmac = new HMACSHA256())
        //     {
        //         // Generate a random 256-bit key
        //         var key = new byte[32]; // 256 bits
        //         using (var rng = new RNGCryptoServiceProvider())
        //         {
        //             rng.GetBytes(key);
        //         }

        //         hmac.Key = key;

        //         var tokenDescriptor = new SecurityTokenDescriptor
        //         {
        //             Subject = new ClaimsIdentity(new[]
        //             {
        //                 new Claim(ClaimTypes.Name, user.Email),
        //                 // Add other claims as needed
        //             }),
        //             Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
        //             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //         };

        //         var token = tokenHandler.CreateToken(tokenDescriptor);
        //         return tokenHandler.WriteToken(token);
        //     }
        // }

        public string GenerateJwtToken(User user)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes("MySuperSecretKey123!$%^&*");
    // Assuming you have a property named "Role" in the User model
    var roleClaim = new Claim(ClaimTypes.Role, user.UserRole);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, user.Email),
            roleClaim,
            // Add other claims as needed
        }),
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}

    }
}
