using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_Crud_Mvvm_MultipleTable.Commands;
using Wpf_Crud_Mvvm_MultipleTable.Models;

namespace Wpf_Crud_Mvvm_MultipleTable.ViewModels
{
    // ViewModels/ProductViewModel.cs
    public class ProductViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private string _newProductName;
        private decimal _newProductPrice;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set { _products = value; OnPropertyChanged(nameof(Products)); }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); }
        }

        public string NewProductName
        {
            get => _newProductName;
            set { _newProductName = value; OnPropertyChanged(nameof(NewProductName)); }
        }

        public decimal NewProductPrice
        {
            get => _newProductPrice;
            set { _newProductPrice = value; OnPropertyChanged(nameof(NewProductPrice)); }
        }

        public ICommand AddProductCommand { get; }
        public ICommand UpdateProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>(); // 
            AddProductCommand = new RelayCommand(AddProduct);
            UpdateProductCommand = new RelayCommand(UpdateProduct, CanUpdateOrDelete);
            DeleteProductCommand = new RelayCommand(DeleteProduct, CanUpdateOrDelete);
        }

        private void AddProduct()
        {
            var product = new Product { Name = NewProductName, Price = NewProductPrice, ManufactureDate = DateTime.Now };
            Products.Add(product);
            NewProductName = string.Empty;
            NewProductPrice = 0;
        }

        private void UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                SelectedProduct.Name = NewProductName;
                SelectedProduct.Price = NewProductPrice;
            }
        }

        private void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                Products.Remove(SelectedProduct);
                SelectedProduct = null;
            }
        }

        private bool CanUpdateOrDelete() => SelectedProduct != null;
    }

}
