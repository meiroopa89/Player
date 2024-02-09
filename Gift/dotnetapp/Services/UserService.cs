using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface UserService
    {
        User register(User user);
        User login(User user);
        string GenerateJwtToken(User user);
    }
}
