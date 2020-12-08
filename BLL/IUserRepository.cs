using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserRepository
    {
        void New(User user);
       
        User Show(int id);

        User GetByEmail(string email);
        string Logout(int id);
        string LogIn(int id);

        IEnumerable<User> List();
    }
}
