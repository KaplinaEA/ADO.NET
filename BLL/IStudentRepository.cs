using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStudentRepository
    {
        string Edit(int id, DateTime birthday, string studentClass);
        IEnumerable<Journal> GetJournal(int id);
        Student Show(int id);
    }
}
