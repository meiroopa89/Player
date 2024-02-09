// Repositories/UserRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User RegisterUser(User user)
        {
            // Check if the email is already registered
            if (_users.Any(u => u.Email == user.Email))
            {
                return null; // Email already exists, registration failed
            }

            // Assign a new UserId
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
