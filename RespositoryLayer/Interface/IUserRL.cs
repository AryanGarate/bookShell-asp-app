using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RespositoryLayer.Entity;

namespace RespositoryLayer.Interface
{
    public interface IUserRL
    {
        User CreateUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User UpdateUser(int id, User user);
        User DeleteUser(int id);
    }
}
