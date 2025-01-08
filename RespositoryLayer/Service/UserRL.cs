using System;
using System.Threading.Tasks;

using RespositoryLayer.ContextDB;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RespositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly BookEcommerceContext _context;

        public UserRL(BookEcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User UpdateUser(int id, User user)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                throw new Exception($"User with ID {id} does not exist");
            }

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Status = user.Status;
            existingUser.UpdatedAt = DateTime.Now;

            _context.Users.Update(existingUser);
            _context.SaveChanges();
            return existingUser;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} does not exist");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
    }
}
