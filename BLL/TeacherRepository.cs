using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TeacherRepository : ITeacherRepository
    {
        ITeacherDao teacherDao;

        public TeacherRepository()
        {
            this.teacherDao = new TeacherDao();
        }
        public string Edit(int id, DateTime birthday, int experience)
        {
            return teacherDao.Edit(id,birthday, experience);
        }
        public Teacher Show(int id)
        {
            return teacherDao.Show(id);
        }
    }
}
