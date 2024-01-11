using ExamenRetry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRetry.ViewModels
{
    class ProductModel
    {
        private Product _product;

        public Product Product { get { return _product; } }
        public ProductModel(Product product)
        {
            _product = product;
        }

        public string ProductName
        {
            get
            {
                return _product.ProductName;
            }
        }

        public int ProductId
        {
            get 
            {
                return _product.ProductId;
            }
        }

        public string? ProductSupplier
        {
            get
            {
                return _product.Supplier?.CompanyName ?? string.Empty;
            }
        } 
        
        public string ProductCategory
        {
            get
            {
                return _product.Category?.CategoryName ?? string.Empty;
            }    
        }

    }
}
