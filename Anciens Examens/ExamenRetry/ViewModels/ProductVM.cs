using ExamenRetry.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamenRetry.ViewModels
{
    class ProductVM : INotifyPropertyChanged
    {
        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        private NorthwindContext dc = new();

        private DelegateCommand _removeCommand;

        private ProductModel _selectedProcuct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProcuct; }
            set { _selectedProcuct = value; }
        }

        public ObservableCollection<ProductModel> ProductList
        {
            get
            {
                return LoadProductList();
            }

        }

        private ObservableCollection<ProductModel> LoadProductList()
        {
            ObservableCollection<ProductModel> localCollection = new();
            foreach (Product item in dc.Products.Where(p => !p.Discontinued))
            {
                localCollection.Add(new(item));
            }
            return localCollection;

        }


        public DelegateCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??= new(RemoveProduct);
            }

        }

        private void RemoveProduct() {
            Product? product = SelectedProduct?.Product;
            if (product == null) { return; }
            product.Discontinued = true;
            dc.Products
                .Update(product);
            dc.SaveChanges();
            OnPropertyChanged("ProductList");
            MessageBox.Show("Enregistrement en base de données fait");
        }

        
    }
}
