using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStudentDao
    {
        string Edit(int id, DateTime birthday, string studentClass);
        Journal GetJournal(int id);

        Student Show(int id);
    }
}
