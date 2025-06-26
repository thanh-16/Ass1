using Service;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
        private string _errorMessage;
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(); } }

        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly CustomerService _customerService = new CustomerService();
        public ICommand LoginCommand { get; }
        public event Action RequestClose;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;

            var employee = _employeeService.Authenticate(Username, password);
            if (employee != null)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                RequestClose?.Invoke();
                return;
            }

            var customer = _customerService.GetCustomerByPhone(Username);
            if (customer != null && Username == password) // Giả định mật khẩu của khách hàng là SĐT
            {
                // TODO: Mở cửa sổ dành cho khách hàng
                ErrorMessage = $"Welcome Customer: {customer.ContactName}";
                // RequestClose?.Invoke(); // Mở cửa sổ customer rồi đóng
                return;
            }

            ErrorMessage = "Invalid username or password.";
        }
    }
}