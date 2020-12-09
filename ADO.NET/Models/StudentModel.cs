using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO.NET.Models
{
    public class StudentModel
    {
        public string studentClass { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}