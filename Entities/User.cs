using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string password { get; set; }
        public int userRole { get; set; }

        public bool login { get; set; }

        public override string ToString()
        {
            return base.ToString() + userName;
        }
        public User() { }
        public User(string email, string password) {
            this.email = email;
            this.password = Convert.ToBase64String((new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(password))));
        }
        public User(string email, string userName, string password,int userRole, int id)
        {
            this.id = id;
            this.email = email;
            this.userName = userName;
            this.userRole = userRole;
            this.password = Convert.ToBase64String((new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(password))));
        }
    }
}
