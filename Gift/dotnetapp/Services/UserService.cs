using dotnetapp.Models;

using namespace.Services
{
    public interface UserService
    {
        User RegisterUser(User user);
        User LoginUser(User user);
    }
}
