using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.UnitsOfWork
{
    internal class UnitOfWorkSchoolSQLServer : IUnitOfWorkSchool
    {
        SchoolContext schoolContext = new SchoolContext();
        public IRepository<Section> SectionsRepo => new BaseRepositorySQL<Section>(schoolContext);

        public IStudentRepository StudentsRepo => new StudentsRepository(schoolContext);
    }
}
