// Repositories/UserRepository.cs
using System.Linq;
using dotnetapp.Models;
using dotnetapp.Data;

namespace dotnetapp.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User RegisterUser(User user)
        {
            // Check if the email is already registered in the database
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return null; // Email already exists, registration failed
            }

            // Assign a new UserId
            user.UserId = System.Guid.NewGuid().GetHashCode();

            // Add user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User LoginUser(User user)
        {
            // Find the user with the provided email and password in the database
            var authenticatedUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            return authenticatedUser;
        }
    }
}
