using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataAccessLayer;
using BusinessObjects;
using System.Windows;

namespace WpfApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username = string.Empty;
        private string _password = string.Empty;
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }

        private readonly IEmployeeRepository _repo;
        private readonly ICustomerRepository _customerRepo;
        private readonly Window _window;

        public LoginViewModel(IEmployeeRepository empRepo, ICustomerRepository custRepo, Window window)
        {
            _repo = empRepo;
            _customerRepo = custRepo;
            _window = window;
            LoginCommand = new RelayCommand(Login);
        }

        public void Login(object? obj = null)
        {
            if (Username.All(char.IsDigit) && Username.Length >= 8 && Username.Length <= 15)
            {
                var cust = _customerRepo.GetAll().FirstOrDefault(c => c.Phone == Username);
                if (cust != null)
                {
                    var customerWindow = new CustomerWindow(cust);
                    customerWindow.Show();
                    _window.Close();
                }
                else
                {
                    MessageBox.Show("Số điện thoại không đúng!");
                }
            }
            else 
            {
                var emp = _repo.GetAll().FirstOrDefault(e => e.UserName == Username && e.Password == Password);
                if (emp != null)
                {
                    var adminWindow = new AdminWindow();
                    adminWindow.Show();
                    _window.Close();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand        
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}