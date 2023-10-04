using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(int id);
        List<User> GetAllUsers();
    }
}
