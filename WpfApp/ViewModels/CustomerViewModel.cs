using BusinessObjects;
using DataAccessLayer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace WpfApp.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerRepository _repo;
        public ObservableCollection<Customer> Customers { get; set; }
        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(nameof(SearchText)); Search(); }
        }

        public CustomerViewModel(ICustomerRepository repo)
        {
            _repo = repo;
            Customers = new ObservableCollection<Customer>(_repo.GetAll());
        }

        public void Add(Customer customer)
        {
            _repo.Add(customer);
            Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _repo.Update(customer);

        }

        public void Delete(Customer customer)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _repo.Delete(customer.CustomerID);
                Customers.Remove(customer);
            }
        }

        public void Search()
        {
            Customers.Clear();
            foreach (var c in _repo.GetAll().Where(c => c.CompanyName.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)))
                Customers.Add(c);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
