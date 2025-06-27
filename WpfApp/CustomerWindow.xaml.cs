using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using DataAccessLayer;

namespace WpfApp
{
    public partial class CustomerWindow : Window
    {
        public Customer Customer { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            Customer = customer;

            var orderRepo = new OrderRepository();
            Orders = new ObservableCollection<Order>(orderRepo.GetAll().Where(o => o.CustomerID == customer.CustomerID));

            // Binding đúng cách
            DataContext = this;
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            var popup = new AddEditCustomerWindow(Customer);
            if (popup.ShowDialog() == true)
            {
                // Cập nhật thông tin cá nhân
                var customerRepo = new CustomerRepository();
                customerRepo.Update(popup.Customer);

                Customer.CompanyName = popup.Customer.CompanyName;
                Customer.ContactName = popup.Customer.ContactName;
                Customer.ContactTitle = popup.Customer.ContactTitle;
                Customer.Address = popup.Customer.Address;
                Customer.Phone = popup.Customer.Phone;

                // Refresh UI
                DataContext = null;
                DataContext = this;

                MessageBox.Show("Cập nhật thông tin thành công!");
            }
        }

        private void ViewOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int orderId)
            {
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

                if (details.Count > 0)
                {
                    var popup = new OrderDetailPopupWindow(details);
                    popup.Owner = this;
                    popup.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đơn hàng này không có sản phẩm nào!");
                }
            }
        }
    }
}