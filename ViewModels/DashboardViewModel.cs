using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Crud_Mvvm_MultipleTable.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title)); // 
            }
        }

        public DashboardViewModel()
        {
            Title = "Welcome to Dashboard!"; // 
        }
    }
}
