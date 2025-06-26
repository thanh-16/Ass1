using System.Windows;
using WpfApp.ViewModels;
using Service;
using DataAccessLayer;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public OrderDetailViewModel OrderDetailVM { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            var repo = new OrderDetailRepository();
            var service = new OrderDetailService(repo);
            OrderDetailVM = new OrderDetailViewModel(service);
            DataContext = OrderDetailVM;
        }
    }
}