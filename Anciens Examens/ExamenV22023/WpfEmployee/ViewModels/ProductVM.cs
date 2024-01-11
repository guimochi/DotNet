using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2023.ViewModels;
using Examen2023.Models;

namespace Examen2023.ViewModels
{
    internal class ProductVM
    {
        private NorthwindContext dc = new();

        private ObservableCollection<ProductModel> _productList;

        public ObservableCollection<ProductModel> ProductList
        {
            get
            {
                return _productList ??= LoadProductList();

            }
        }

        private ObservableCollection<ProductModel> LoadProductList()
        {
            Console.WriteLine("List");
            ObservableCollection<ProductModel> localCollection = new ObservableCollection<ProductModel>();
            foreach (var item in dc.Products.Include("Supplier").Include("Category"))
            {
                localCollection.Add(new ProductModel(item));

            }
            return localCollection;
        }

    }
}
