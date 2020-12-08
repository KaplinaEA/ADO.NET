using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Homework 
    {
        //[Key]
        public int id { get; set; }
        //[Required]
        public string name { get; set; }
        public string text { get; set; }


        public Homework() { }
        public Homework(string name, string text = null)
        {
            this.name = name;
            this.text = text;
        }
    }
}
