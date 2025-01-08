using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RespositoryLayer.Entity;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        User CreateUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User UpdateUser(int id, User user);
        User DeleteUser(int id);
    }
}
