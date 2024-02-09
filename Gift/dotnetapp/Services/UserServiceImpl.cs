// Services/UserServiceImpl.cs
using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public class UserServiceImpl : UserService
    {
        private readonly List<User> _users = new List<User>();

        public User RegisterUser(User user)
        {
            // Check if the email is already registered
            if (_users.Any(u => u.Email == user.Email))
            {
                return null; // Email already exists, registration failed
            }

            // Assign a new UserId using GUID hash code
            user.UserId = Guid.NewGuid().GetHashCode();

            // Add user to the list (or save to database)
            _users.Add(user);

            return user;
        }

        public User LoginUser(User user)
        {
            // Find the user with the provided email and password
            var authenticatedUser = _users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            return authenticatedUser;
        }
    }
}
