using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentRepository : IStudentRepository
    {
        IStudentDao studentDao;

        public StudentRepository()
        {
            this.studentDao = new StudentDao();
        }
        public string Edit(int id, DateTime birthday, string studentClass)
        {
            return studentDao.Edit(id, birthday, studentClass);
        }
        public Journal GetJournal(int id)
        {
            return studentDao.GetJournal(id);
        }

        public Student Show(int id)
        {
            return studentDao.Show(id);
        }
    }
}
