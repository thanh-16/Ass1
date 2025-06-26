using BusinessLogicLayer;
using BusinessObjects;
using Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly CustomerService _customerService;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        private string _searchTerm;

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set { _customers = value; OnPropertyChanged(); }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                (DeleteCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (UpdateCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set { _searchTerm = value; OnPropertyChanged(); }
        }

        public ICommand LoadDataCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public CustomerViewModel()
        {
            _customerService = new CustomerService();
            LoadDataCommand = new RelayCommand(LoadData);
            AddCommand = new RelayCommand(AddCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer, () => SelectedCustomer != null);
            DeleteCommand = new RelayCommand(DeleteCustomer, () => SelectedCustomer != null);
            SearchCommand = new RelayCommand(SearchData);
            LoadData(null);
        }

        private void LoadData(object obj)
        {
            Customers = new ObservableCollection<Customer>(_customerService.GetCustomers());
        }

        private void SearchData(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                LoadData(null);
            }
            else
            {
                Customers = new ObservableCollection<Customer>(_customerService.SearchCustomer(SearchTerm));
            }
        }

        private void AddCustomer(object obj)
        {
            var newCustomer = new Customer();
            var vm = new AddEditCustomerViewModel(newCustomer);
            var window = new AddEditCustomerWindow { DataContext = vm };

            if (window.ShowDialog() == true)
            {
                _customerService.AddCustomer(vm.CurrentCustomer);
                LoadData(null);
            }
        }

        private void UpdateCustomer(object obj)
        {
            var vm = new AddEditCustomerViewModel(SelectedCustomer);
            var window = new AddEditCustomerWindow { DataContext = vm };

            if (window.ShowDialog() == true)
            {
                _customerService.UpdateCustomer(vm.CurrentCustomer);
                LoadData(null);
            }
        }

        private void DeleteCustomer(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _customerService.DeleteCustomer(SelectedCustomer.CustomerID);
                LoadData(null);
            }
        }
    }
}