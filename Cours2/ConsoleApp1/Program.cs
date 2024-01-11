using LINQDataContext;

DataContext dc = new DataContext();

Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    Console.WriteLine(jdepp.Last_Name + jdepp.First_Name);
}

Console.WriteLine("---------------------Exerice 2.2---------------------");

var query2_2 = from s in dc.Students
                   select new { EntireName = s.First_Name + " " + s.Last_Name, ID = s.Student_ID, BirthDate = s.BirthDate };

foreach (var result in query2_2)
{
    Console.WriteLine("{0} {1} {2}", result.EntireName, result.ID, result.BirthDate);
}

Console.WriteLine("---------------------Exerice 3.1---------------------");

var query3_1  = from s in dc.Students
                where s.BirthDate.Year < 1955
                select new {Name=s.Last_Name, Result = s.Year_Result, Statut = s.Year_Result < 12 ? "KO" : "OK"};
foreach (var result in query3_1)
{
    Console.WriteLine("{0} {1} {2}", result.Name, result.Result, result.Statut);
}

Console.WriteLine("---------------------Exercice 3.4---------------------");

var query3_4 = from s in dc.Students
               where s.Year_Result <= 3
               orderby s.Year_Result descending
               select new { Name = s.Last_Name, Result = s.Year_Result };

foreach (var result in query3_4)
{
    Console.WriteLine("{0} {1}", result.Result, result.Name);
}

Console.WriteLine("---------------------Exercice 3.5---------------------");

var query3_5 = from s in dc.Students
               where s.Section_ID == 1110
               orderby s.Year_Result ascending
               select new {FullName = s.First_Name + " " +  s.Last_Name, Result = s.Year_Result};

foreach (var result in query3_5)
{
    Console.WriteLine(result);
}

Console.WriteLine("---------------------Exercice 4.1---------------------");

double query4_1 = dc.Students.Average(s => s.Year_Result);

Console.WriteLine("Average = " + query4_1.ToString());

Console.WriteLine("---------------------Exercice 5.1---------------------");

var query5_1 = dc.Students
    .GroupBy(s => s.Section_ID)
    .Select(s => new { Section_ID = s.Key, Max = s.Max(el => el.Year_Result) });

foreach (var s in query5_1)
{
    Console.WriteLine("{0}", s);
}

Console.WriteLine("---------------------Exercice 5.3---------------------");

var query5_3 = dc.Students
    .Where(s => s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985)
    .GroupBy(s => s.BirthDate.Month)
    .Select(e => new { AVG_Result = e.Average(s => (float)s.Year_Result), BirthMonth = e.Key });

foreach (var s in query5_3)
{ Console.WriteLine("{0}", s); }

Console.WriteLine("---------------------Exercice 5.7---------------------");

var query5_7 = dc.Sections
    .GroupJoin(dc.Professors,
    s => s.Section_ID,
    p => p.Section_ID,
    (s, p) => new { Section_ID = s.Section_ID, Section_Name = s.Section_Name, Professors = p });

foreach (var s in query5_7)
{
    Console.WriteLine("{0} -> {1} : ", s.Section_ID, s.Section_Name);
    bool empty = true;
    foreach (var p in s.Professors)
    {
        empty = false;
        Console.WriteLine("{0} {1}", p.Professor_Name, p.Professor_Surname);
    }
    if (empty)
    {
        Console.WriteLine("Aucun");
    }
}

Console.WriteLine();
var QueryResult22 = dc.Sections
    .Join(dc.Professors, s => s.Section_ID, p => p.Section_ID, (s, p) => new { s, p })
    .Select(s => new { Id_Section = s.s.Section_ID, Nom_Section = s.s.Section_Name, Nom_Professeur = s.p.Professor_Name });

foreach (var Result in QueryResult22)
{
    Console.WriteLine(Result);
}

