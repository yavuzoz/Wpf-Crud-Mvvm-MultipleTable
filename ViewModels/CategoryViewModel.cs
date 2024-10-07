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
    // ViewModels/CategoryViewModel.cs
    public class CategoryViewModel : ViewModelBase
    {
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        private string _newCategoryName;

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set { _categories = value; OnPropertyChanged(nameof(Categories)); }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set { _selectedCategory = value; OnPropertyChanged(nameof(SelectedCategory)); }
        }

        public string NewCategoryName
        {
            get => _newCategoryName;
            set { _newCategoryName = value; OnPropertyChanged(nameof(NewCategoryName)); }
        }

        public ICommand AddCategoryCommand { get; }
        public ICommand UpdateCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>(); // 
            AddCategoryCommand = new RelayCommand(AddCategory);
            UpdateCategoryCommand = new RelayCommand(UpdateCategory, CanUpdateOrDelete);
            DeleteCategoryCommand = new RelayCommand(DeleteCategory, CanUpdateOrDelete);
        }

        private void AddCategory()
        {
            var category = new Category { CategoryName = NewCategoryName };
            Categories.Add(category);
            NewCategoryName = string.Empty;
        }

        private void UpdateCategory()
        {
            if (SelectedCategory != null)
            {
                SelectedCategory.CategoryName = NewCategoryName;
            }
        }

        private void DeleteCategory()
        {
            if (SelectedCategory != null)
            {
                Categories.Remove(SelectedCategory);
                SelectedCategory = null;
            }
        }

        private bool CanUpdateOrDelete() => SelectedCategory != null;
    }

}
