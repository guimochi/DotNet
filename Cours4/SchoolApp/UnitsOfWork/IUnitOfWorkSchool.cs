using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.UnitsOfWork
{
    interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionsRepo { get; }
        IStudentRepository StudentsRepo { get; }
    }
}
