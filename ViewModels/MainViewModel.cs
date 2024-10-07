using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_Crud_Mvvm_MultipleTable.Commands;

namespace Wpf_Crud_Mvvm_MultipleTable.ViewModels
{
    // ViewModels/MainViewModel.cs
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowCategoryCommand { get; }
        public ICommand ShowProductCommand { get; }

        public MainViewModel()
        {
            ShowDashboardCommand = new RelayCommand(ShowDashboard);
            ShowCategoryCommand = new RelayCommand(ShowCategory);
            ShowProductCommand = new RelayCommand(ShowProduct);

            // Varsayılan olarak DashboardViewModel yükleniyor
            CurrentViewModel = new DashboardViewModel();
        }

        private void ShowDashboard()
        {
            CurrentViewModel = new DashboardViewModel();
        }

        private void ShowCategory()
        {
            CurrentViewModel = new CategoryViewModel(); // CategoryViewModel'ın da bir UI görünümüne bağlandığından emin olun
        }

        private void ShowProduct()
        {
            CurrentViewModel = new ProductViewModel(); // ProductViewModel'ın da bir UI görünümüne bağlandığından emin olun
        }
    }

}
