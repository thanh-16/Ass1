using System;
using System.Linq;
using System.Windows;
using DataAccessLayer;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
            
            var now = DateTime.Now;
            FromDatePicker.SelectedDate = new DateTime(now.Year, now.Month, 1);
            ToDatePicker.SelectedDate = now;
            
            LoadOrders();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orderRepo = new OrderRepository();
            var customerRepo = new CustomerRepository();
            var employeeRepo = new EmployeeRepository();
            var orderDetailRepo = new OrderDetailRepository();

            var fromDate = FromDatePicker.SelectedDate ?? DateTime.MinValue;
            var toDate = ToDatePicker.SelectedDate ?? DateTime.MaxValue;

            var allOrders = orderRepo.GetAll().ToList();
            var allCustomers = customerRepo.GetAll().ToList();
            var allEmployees = employeeRepo.GetAll().ToList();

            var orders = allOrders
                .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    CustomerName = allCustomers.FirstOrDefault(c => c.CustomerID == o.CustomerID)?.CompanyName ?? "N/A",
                    EmployeeName = allEmployees.FirstOrDefault(e => e.EmployeeID == o.EmployeeID)?.Name ?? "N/A",
                    Total = orderDetailRepo.GetByOrderId(o.OrderID)
                        .Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount)),
                    ProductCount = orderDetailRepo.GetByOrderId(o.OrderID).Count()
                })
                .ToList();

            OrdersGrid.ItemsSource = orders;
        }
    }
}
