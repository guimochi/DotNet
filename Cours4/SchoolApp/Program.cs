using SchoolApp.Models;
using SchoolApp.Repository;
using SchoolApp.UnitsOfWork;

IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolSQLServer();
IRepository<Section> sectionsRepository = unitOfWorkSchool.SectionsRepo;

Section sectInfo = new Section { Name = "sectInfo" };
sectionsRepository.Save(sectInfo, s => s.Name.Equals(sectInfo.Name));

Section sectDiet = new Section { Name = "sectDiet" };
sectionsRepository.Save(sectDiet, s => s.Name.Equals(sectDiet.Name));

IList<Section> sections = sectionsRepository.GetAll();

Console.WriteLine("All sections :");
foreach (Section section in sections)
{
    Console.WriteLine(section.Name);
}

IStudentRepository studentsRepository = unitOfWorkSchool.StudentsRepo;
Student studinfo1 = new Student
{
    Firstname = "studinfo1",
    Name = "studinfo1",
    YearResult = 100,
    Section = sectionsRepository.SearchFor(s => s.Name.Equals("sectInfo")).First()
};

studentsRepository.Save(studinfo1, s => s.Name.Equals(studinfo1.Name) && s.Firstname.Equals(studinfo1.Firstname));


IList<Student> students = studentsRepository.GetStudentBySectionOrderByYearResult();

Console.WriteLine("All student sorted :");
foreach (Student student in students)
{
    Console.WriteLine("{0} {1}", student.Firstname, student.Name);
}

