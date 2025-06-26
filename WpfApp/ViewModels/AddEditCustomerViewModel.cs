using BusinessObjects;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class AddEditCustomerViewModel : ViewModelBase
    {
        public string WindowTitle { get; set; }
        public Customer CurrentCustomer { get; set; }

        // Các thuộc tính để binding với các TextBox trên giao diện
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICommand SaveCommand { get; }

        public AddEditCustomerViewModel(Customer customer)
        {
            CurrentCustomer = customer;

            // Nạp dữ liệu từ customer được truyền vào để hiển thị
            CompanyName = customer.CompanyName;
            ContactName = customer.ContactName;
            ContactTitle = customer.ContactTitle;
            Address = customer.Address;
            Phone = customer.Phone;

            WindowTitle = customer.CustomerID == 0 ? "Add New Customer" : "Update Customer";

            SaveCommand = new RelayCommand(Save);
        }

        private void Save(object parameter)
        {
            // TODO: Thêm Validate dữ liệu ở đây

            // Cập nhật lại thông tin cho đối tượng Customer từ các TextBox
            CurrentCustomer.CompanyName = CompanyName;
            CurrentCustomer.ContactName = ContactName;
            CurrentCustomer.ContactTitle = ContactTitle;
            CurrentCustomer.Address = Address;
            CurrentCustomer.Phone = Phone;

            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}