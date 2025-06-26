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
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly CustomerService _customerService = new CustomerService();
        public ICommand LoginCommand { get; }
        public event Action RequestClose;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin(object parameter)
        {
            // Cho phép nhấn nút Login khi có nhập Username/Phone
            return !string.IsNullOrEmpty(Username);
        }

        private void Login(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            if (passwordBox == null) return;
            var password = passwordBox.Password;

            // Kiểm tra đăng nhập với tư cách Admin (Employee)
            var employee = _employeeService.Authenticate(Username, password);
            if (employee != null)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                RequestClose?.Invoke(); // Gửi yêu cầu đóng cửa sổ Login
                return;
            }

            // Kiểm tra đăng nhập với tư cách Customer (bằng SĐT)
            var customer = _customerService.GetCustomerByPhone(Username);
            // Giả định: mật khẩu của khách hàng chính là SĐT của họ
            if (customer != null && password == customer.Phone)
            {
                // TODO: Mở cửa sổ dành cho Customer
                ErrorMessage = $"Welcome Customer: {customer.ContactName}";
                // RequestClose?.Invoke(); // Khi có cửa sổ Customer thì mở dòng này
                return;
            }

            ErrorMessage = "Invalid username or password.";
        }
    }
}