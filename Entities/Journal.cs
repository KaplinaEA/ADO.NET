using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Journal
    {
        public string name { get; set; }
        public string text { get; set; }
        public int grade { get; set; }

        public Journal() { }
        public Journal(string name, string text, int grade)
        {
            this.name = name;
            this.text = text;
            this.grade = grade;
        }
    }
}
