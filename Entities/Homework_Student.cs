using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Homework_Student 
    {
        public Student student { get; set; }
        public Homework homework { get; set; }

        public int grade { get; set; }
        
        public Homework_Student(Student s, Homework h, int g)
        {
            this.student = s;
            this.homework = h;
            this.grade = g;
        }
    }
}
