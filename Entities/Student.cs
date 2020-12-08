using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Student: User 
    {
        public string studentClass { get; set; }

        public Student() : base() { }
        public Student(string email, string userName, string password, int role, int id):
            base(email, userName, password, role,  id)
        {            
        }

        public Student(string email, string userName, string password, int role, int id, string studentClass) :
                    base(email, userName, password, role, id)
        {
            this.studentClass = studentClass;
        }
    }
}
