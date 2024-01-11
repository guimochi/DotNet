using Console_App.Models;
using Microsoft.EntityFrameworkCore;

NorthwindContext context = new NorthwindContext();

// 1.	Lister tous les Customers habitants dans une ville saisie au clavier.

//Console.WriteLine("Entrez le nom d'une ville :");
//string? read = Console.ReadLine();

//IQueryable<Customer> customers = dbCt.Customers
//    .Where(c => c.City == read);

//foreach (Customer c in customers)
//{
//    Console.WriteLine(c.ContactName);
//}

// 2.	Afficher les produits de la catégorie Beverages et Condiments. Utilisez le lazy loading  (pas d’include !)
//var query1 = dbCt.Categories
//    .Where(c => c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
//    .GroupJoin(dbCt.Products, 
//    c => c.CategoryId, 
//    p => p.CategoryId, 
//    (c, p) => new { CategoryName = c.CategoryName, Products = p.Select(el => el.ProductName) });

//foreach (var tuple in query1)
//{
//    Console.WriteLine("Categorie : {0}", tuple.CategoryName);
//    foreach (var product in tuple.Products)
//    {
//        Console.WriteLine(product);
//    }

//}

//3.Afficher les produits de la catégorie Beverages et Condiments. Utilisez le eager loading ! (avec include).  Le résultat est identique à la requête précédente.
//var query2 = dbCt.Categories
//    .Include("Products")
//    .Where(c => c.CategoryName == "Beverages" || c.CategoryName == "Condiments");



//foreach (var tuple in query2)
//{
//    Console.WriteLine("Categorie : {0}", tuple.CategoryName);
//    foreach (var product in tuple.Products)
//    {
//        Console.WriteLine(product.ProductName);
//    }

//}

//Exercice 4
//Console.WriteLine("Entrez l'ID du client : ");

//string? idInput = Console.ReadLine();

//var query3 = dbCt.Orders
//    .Where(o => o.CustomerId == idInput && o.ShippedDate.HasValue)
//    .OrderByDescending(o => o.OrderDate);

//foreach (var tuple in query3)
//{
//    Console.WriteLine("Customer ID : {0} Orde date : {1} ShippedDate : {2}", tuple.CustomerId, tuple.OrderDate, tuple.ShippedDate);
//}


//Exercice 5
//var query5 = context.OrderDetails
//    .GroupBy(x => x.ProductId)
//    .OrderBy(x => x.Key)
//    .Select(x => new { ProductID = x.Key, Total = x.Sum(e => e.Quantity * e.UnitPrice) });

//foreach(var tuple in query5)
//{

//    Console.WriteLine("{0} ----> {1}",tuple.ProductID, tuple.Total);
//}

//Exercice 6
//IQueryable<Employee> query6 = context.Employees
//    .Where(e => e.Territories.Any(t => t.Region.RegionDescription == "Western"));


//Console.WriteLine("Liste des employes de la region Western");
//foreach  (var e in query6)
//{
//    Console.WriteLine("{0} {1}", e.FirstName, e.LastName);
//}

////Exercice 7
//var query7 = context.Employees
//    .Include("Territories")
//    .Where(e => e.EmployeeId == context.Employees.Where(el => el.LastName == "Suyama" && el.FirstName == "Michael").FirstOrDefault().EmployeeId)
//    .FirstOrDefault()
//    .Territories.ToArray();

//Console.WriteLine("Les territoires geres par le superieur de Suyama Michael");
//foreach (Territory e in query7)
//{
//    Console.WriteLine(e.TerritoryDescription);
//}

IQueryable<Customer> customers1 = context.Customers;

foreach (Customer customer in customers1)
{
    customer.ContactName = customer.ContactName?.ToUpper();
}

context.SaveChanges();

IQueryable<Customer> customers2 = context.Customers;

foreach (Customer c in customers2)
{
    Console.WriteLine($"{c.ContactName}");
}