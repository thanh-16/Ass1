using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataAccessLayer;
using BusinessObjects;

namespace WpfApp
{
    public partial class OrderManagementWindow : Window
    {
        public OrderManagementWindow()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orderRepo = new OrderRepository();
            var customerRepo = new CustomerRepository();
            var employeeRepo = new EmployeeRepository();
            var orderDetailRepo = new OrderDetailRepository();

            var orders = orderRepo.GetAll()
                .Select(o => new
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    CustomerName = customerRepo.GetById(o.CustomerID)?.CompanyName ?? "N/A",
                    EmployeeName = employeeRepo.GetById(o.EmployeeID)?.Name ?? "N/A",
                    Total = orderDetailRepo.GetByOrderId(o.OrderID)
                        .Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
                })
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            OrderGrid.ItemsSource = orders;
        }

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateOrderWindow();
            if (createWindow.ShowDialog() == true)
            {
                LoadOrders();
            }
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                dynamic selectedOrder = OrderGrid.SelectedItem;
                int orderId = selectedOrder.OrderID;

                var orderDetailRepo = new OrderDetailRepository();
                var productRepo = new ProductRepository();
                var details = orderDetailRepo.GetByOrderId(orderId)
                    .Select(od => new
                    {
                        ProductID = od.ProductID,
                        ProductName = productRepo.GetById(od.ProductID)?.ProductName ?? "N/A",
                        UnitPrice = od.UnitPrice,
                        Quantity = od.Quantity,
                        Discount = od.Discount,
                        Total = od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount)
                    }).ToList();

                var popup = new OrderDetailPopupWindow(details);
                popup.Owner = this;
                popup.ShowDialog();
            }
            else
            {
                MessageBox.Show("chọn đơn hàng để xem chi tiết!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa đơn hàng này?", "Xác nhận",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    dynamic selectedOrder = OrderGrid.SelectedItem;
                    int orderId = selectedOrder.OrderID;

                    var orderRepo = new OrderRepository();
                    var orderDetailRepo = new OrderDetailRepository();

                    var details = orderDetailRepo.GetByOrderId(orderId);
                    foreach (var detail in details)
                    {
                        orderDetailRepo.Delete(detail.OrderID, detail.ProductID);
                    }

                    orderRepo.Delete(orderId);

                    MessageBox.Show("Xóa đơn hàng thành công");
                    LoadOrders();
                }
            }
            else
            {
                MessageBox.Show("chọn đơn hàng cần xóa");
            }
        }
    }
}