using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDao
    {
        void New(User user);
   
        User Show(int id);

        User GetByEmail(string email);

        string Logout(int id);

        string Login(int id);

        IEnumerable<User> List();
    }
}
