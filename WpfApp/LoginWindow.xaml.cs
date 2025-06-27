using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.ViewModels;
using DataAccessLayer;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var empRepo = new EmployeeRepository();
            var custRepo = new CustomerRepository();
            DataContext = new LoginViewModel(empRepo, custRepo, this);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is WpfApp.ViewModels.LoginViewModel vm)
            {
                vm.Password = PasswordBox.Password;
                vm.LoginCommand.Execute(null);
            }
        }
    }
}
