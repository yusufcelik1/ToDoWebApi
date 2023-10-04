using DataAccessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Get user by ID (Read)
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.ID == id);
        }

        // Create a new user
        public User CreateUser(User user)
        {
            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        // Update an existing user
        public User UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.ID == user.ID);

            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                existingUser.Points = user.Points;
                existingUser.Score = user.Score;
                // Add other fields if necessary

                _context.SaveChanges();

                return existingUser;
            }
            return null;
        }

        // Delete a user
        public bool DeleteUser(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.ID == id);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Get all users (optional, based on your needs)
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}