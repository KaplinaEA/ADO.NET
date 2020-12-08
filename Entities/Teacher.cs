using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Teacher:User
    {
        public int experience { get; set; }

        public Teacher() { }
        public Teacher(string email, string userName, string password, int role, int id) :
            base(email, userName, password, role, id)
        {
        }

        public Teacher(string email, string userName, string password, int role, int id, int experience) :
                    base(email, userName, password, role, id)
        {
            this.experience = experience;
        }
    }
}
