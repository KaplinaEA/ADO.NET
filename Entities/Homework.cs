﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Homework 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string text { get; set; }


        public Homework() { }
        public Homework(int id, string name, string text = null)
        {
            this.id = id;
            this.name = name;
            this.text = text;
        }
    }
}
