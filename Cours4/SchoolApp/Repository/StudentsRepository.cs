using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    class StudentsRepository : BaseRepositorySQL<Student> , IStudentRepository
    {
        public StudentsRepository(SchoolContext dbContext) : base(dbContext) { }

        public IList<Student> GetStudentBySectionOrderByYearResult()
        {
            IList<Student> students = base.GetAll();
            students = students
                .OrderBy(s => s.Section?.Name)
                .ThenByDescending(s => s.YearResult)
                .ToList();
            return students;
        }
    }
}
