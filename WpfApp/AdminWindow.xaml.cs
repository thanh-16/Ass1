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
using DataAccessLayer;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var customerRepo = new CustomerRepository();
            var productRepo = new ProductRepository();
            var orderRepo = new OrderRepository();
            var employeeRepo = new EmployeeRepository();

            CustomerCountText.Text = customerRepo.GetAll().Count().ToString();
            ProductCountText.Text = productRepo.GetAll().Count().ToString();
            OrderCountText.Text = orderRepo.GetAll().Count().ToString();
            EmployeeCountText.Text = employeeRepo.GetAll().Count().ToString();
        }

        private void ManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            var customerManagement = new CustomerManagementWindow();
            customerManagement.ShowDialog();
            LoadStatistics(); // Refresh stats after window closes
        }

        private void ManageProducts_Click(object sender, RoutedEventArgs e)
        {
            var productManagement = new ProductManagementWindow();
            productManagement.ShowDialog();
            LoadStatistics();
        }

        private void ManageOrders_Click(object sender, RoutedEventArgs e)
        {
            var orderManagement = new OrderManagementWindow();
            orderManagement.ShowDialog();
            LoadStatistics();
        }

        private void CreateNewOrder_Click(object sender, RoutedEventArgs e)
        {
            var newOrderWindow = new CreateOrderWindow();
            newOrderWindow.ShowDialog();
            LoadStatistics();
        }

        private void ViewReports_Click(object sender, RoutedEventArgs e)
        {
            var reportsWindow = new ReportsWindow();
            reportsWindow.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
