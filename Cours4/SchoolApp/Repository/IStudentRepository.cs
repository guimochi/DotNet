using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    interface IStudentRepository : IRepository<Student>
    {
        public IList<Student> GetStudentBySectionOrderByYearResult();
    }
}
