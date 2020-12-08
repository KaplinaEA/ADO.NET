using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ITeacherDao
    {
        string Edit(int id, string name, DateTime birthday, int experience);
        Teacher Show(int id);
    }
}
