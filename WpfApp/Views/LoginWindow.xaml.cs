using WpfApp.ViewModels;
using System.Windows;

namespace WpfApp.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel();
            this.DataContext = viewModel;
            viewModel.RequestClose += () => { this.Close(); };
        }
    }
}