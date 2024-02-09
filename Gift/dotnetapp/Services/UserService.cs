using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface UserService
    {
        User RegisterUser(User user);
        User LoginUser(User user);
    }
}
