// Services/UserServiceImpl.cs
using dotnetapp.Models;
using dotnetapp.Repositories;

namespace dotnetapp.Services
{
    public class UserServiceImpl : UserService
    {
        private readonly UserRepository _userRepository;

        public UserServiceImpl(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User RegisterUser(User user)
        {
            return _userRepository.RegisterUser(user);
        }

        public User LoginUser(User user)
        {
            return _userRepository.LoginUser(user);
        }
    }
}
