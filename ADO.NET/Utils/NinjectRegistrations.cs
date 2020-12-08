using BLL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO.NET.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IStudentRepository>().To<StudentRepository>();
            Bind<ITeacherRepository>().To<TeacherRepository>();
            Bind<IHomeworkRepository>().To<HomeworkRepository>();
        }
    }
}