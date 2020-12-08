using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HomeworkRepository : IHomeworkRepository
    {
        IHomeworkDao homeworkDao;

        public HomeworkRepository()
        {
            this.homeworkDao = new HomeworkDao();
        }

        public void New(Homework homework)
        {
            homeworkDao.New(homework);
        }
        public string Delete(int id)
        {
            return homeworkDao.Delete(id);
        }

        public IEnumerable<Homework> List()
        {
            return homeworkDao.List();
        }

        public Homework Show(int id)
        {
            return homeworkDao.Show(id);
        }

        public string Edit(int id, string name)
        {
            return homeworkDao.Edit(id, name);
        }
        public string Edit(int id, string name, string text)
        {
            return homeworkDao.Edit(id, name, text);
        }

        public string Edit_Create_Grade(int studetId, int homeworkId, int grade)
        {
            return homeworkDao.Edit_Create_Grade(studetId, homeworkId, grade);
        }
    }
}
