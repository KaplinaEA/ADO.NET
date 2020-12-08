using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserRepository:IUserRepository
    {
        IUserDao userDao;

        public UserRepository()
        {
            this.userDao = new UserDao();
        }
        public void New(User user)
        {
            userDao.New(user);
        }
      
        public User Show(int id)
        {
            return userDao.Show(id);
        }                   

        public User GetByEmail(string email)
        {
            return userDao.GetByEmail(email);
        }

        public string Logout(int id)
        {
            return userDao.Logout(id);
        }

        public string LogIn(int id)
        {
            return userDao.Login(id);
        }

        public IEnumerable<User> List()
        {
            return userDao.List();
        }
    }
}
