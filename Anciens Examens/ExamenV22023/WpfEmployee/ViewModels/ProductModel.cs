using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2023.Models;

namespace Examen2023.ViewModels
{
    class ProductModel
    {
        private Product _product;

        public ProductModel(Product product)
        {
            _product = product;
        }
        public int ProductId 
        { 
            get
            {
                return _product.ProductId;
            }
        }
        public string ProductName
        {
            get
            {
                return _product.ProductName;
            }
        }

        public string? Category
        {
            get
            {
                return _product.Category?.CategoryName;
            }

        }

        public string? Fournisseur
        { 
            get
            {
                return _product.Supplier?.CompanyName;
            }
        }
    }
}
