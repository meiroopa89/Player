// using dotnetapp.Models;

// namespace dotnetapp.Services
// {
//     public interface UserService
//     {
//         User register(User user);
//         User login(User user);
//         string GenerateJwtToken(User user);
//     }
// }


using dotnetapp.Models;
using System.Threading.Tasks;
using dotnetapp.Data;

namespace dotnetapp.Services
{
    public interface IUserService
    {
        Task<(int, string)> Register(RegisterModel model, string role);
        Task<(int, string)> Login(LoginModel model);
    }
}
