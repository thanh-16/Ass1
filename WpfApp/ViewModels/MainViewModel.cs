using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView { get => _currentView; set { _currentView = value; OnPropertyChanged(); } }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowProductViewCommand { get; }

        public MainViewModel()
        {
            ShowCustomerViewCommand = new RelayCommand(p => CurrentView = new CustomerViewModel());
            ShowProductViewCommand = new RelayCommand(p => CurrentView = new ProductViewModel());
            CurrentView = new CustomerViewModel(); // View mặc định
        }
    }
}