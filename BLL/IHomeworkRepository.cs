using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IHomeworkRepository
    {
        void New(Homework homework);
        string Delete(int id);

        IEnumerable<Homework> List();

        Homework Show(int id);

        string Edit(int id, string name);
        string Edit(int id, string name, string text);

        string Edit_Create_Grade(int stidetId, int homeworkId, int grade);
    }
}
