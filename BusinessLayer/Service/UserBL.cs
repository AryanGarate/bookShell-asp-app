using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer.Interface;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL _userRL;

        public UserBL(IUserRL userRL)
        {
            _userRL = userRL ?? throw new ArgumentNullException(nameof(userRL));
        }

        public User CreateUser(User user)
        {
            return _userRL.CreateUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRL.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRL.GetUserById(id);
        }

        public User UpdateUser(int id, User user)
        {
            return _userRL.UpdateUser(id, user);
        }

        public User DeleteUser(int id)
        {
            return _userRL.DeleteUser(id);
        }
    }
}
