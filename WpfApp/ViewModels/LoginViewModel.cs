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
        private readonly Window _window;

        public LoginViewModel(IEmployeeRepository repo, Window window)
        {
            _repo = repo;
            _window = window;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object obj)
        {
            string password = obj as string ?? Password;
            var emp = _repo.GetAll().FirstOrDefault(e => e.UserName == Username && e.Password == password);
            if (emp != null)
            {
                // Ðãng nh?p thành công, m? MainWindow
                var main = new MainWindow();
                main.Show();
                _window.Close();
            }
            else
            {
                MessageBox.Show("Sai tài kho?n ho?c m?t kh?u!");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    // RelayCommand implementation for ICommand
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