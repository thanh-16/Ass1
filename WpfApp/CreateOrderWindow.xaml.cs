using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BusinessObjects;
using DataAccessLayer;

namespace WpfApp
{
    public partial class CreateOrderWindow : Window
    {
        private List<OrderDetailItem> _orderDetails = new List<OrderDetailItem>();

        public CreateOrderWindow()
        {
            InitializeComponent();
            LoadData();
            OrderDatePicker.SelectedDate = DateTime.Now;
        }

        private void LoadData()
        {
            var customerRepo = new CustomerRepository();
            var employeeRepo = new EmployeeRepository();
            var productRepo = new ProductRepository();

            CustomerComboBox.ItemsSource = customerRepo.GetAll();
            CustomerComboBox.DisplayMemberPath = "CompanyName";
            CustomerComboBox.SelectedValuePath = "CustomerID";

            EmployeeComboBox.ItemsSource = employeeRepo.GetAll();
            EmployeeComboBox.DisplayMemberPath = "Name";
            EmployeeComboBox.SelectedValuePath = "EmployeeID";

            ProductComboBox.ItemsSource = productRepo.GetAll();
            ProductComboBox.DisplayMemberPath = "ProductName";
            ProductComboBox.SelectedValuePath = "ProductID";
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductComboBox.SelectedItem is Product selectedProduct &&
                int.TryParse(QuantityBox.Text, out int quantity) &&
                float.TryParse(DiscountBox.Text, out float discount) &&
                quantity > 0 && discount >= 0 && discount <= 1)
            {
                var existing = _orderDetails.FirstOrDefault(od => od.ProductID == selectedProduct.ProductID);
                if (existing != null)
                {
                    existing.Quantity += quantity;
                    existing.Total = existing.UnitPrice * existing.Quantity * (1 - (decimal)existing.Discount);
                }
                else
                {
                    var orderDetail = new OrderDetailItem
                    {
                        ProductID = selectedProduct.ProductID,
                        ProductName = selectedProduct.ProductName,
                        UnitPrice = selectedProduct.UnitPrice,
                        Quantity = quantity,
                        Discount = discount,
                        Total = selectedProduct.UnitPrice * quantity * (1 - (decimal)discount)
                    };
                    _orderDetails.Add(orderDetail);
                }

                OrderDetailsGrid.ItemsSource = null;
                OrderDetailsGrid.ItemsSource = _orderDetails;
                
                UpdateTotal();
                
                QuantityBox.Text = "1";
                DiscountBox.Text = "0";
            }
            else
            {
                MessageBox.Show("chọn sản phẩm và nhập số lượng, giảm giá");
            }
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is int productId)
            {
                var item = _orderDetails.FirstOrDefault(od => od.ProductID == productId);
                if (item != null)
                {
                    _orderDetails.Remove(item);
                    OrderDetailsGrid.ItemsSource = null;
                    OrderDetailsGrid.ItemsSource = _orderDetails;
                    UpdateTotal();
                }
            }
        }

        private void UpdateTotal()
        {
            var total = _orderDetails.Sum(od => od.Total);
            TotalText.Text = $"{total:N0} VNĐ";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedValue == null)
            {
                MessageBox.Show("chọn khách hàng");
                return;
            }

            if (EmployeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("chọn nhân viên");
                return;
            }

            if (!_orderDetails.Any())
            {
                MessageBox.Show("thêm ít nhất một sản phẩm");
                return;
            }

            try
            {
                var orderRepo = new OrderRepository();
                var orderDetailRepo = new OrderDetailRepository();

                var allOrders = orderRepo.GetAll().ToList();
                var newOrderId = allOrders.Count > 0 ? allOrders.Max(o => o.OrderID) + 1 : 1;
                
                var order = new Order
                {
                    OrderID = newOrderId,
                    CustomerID = (int)CustomerComboBox.SelectedValue,
                    EmployeeID = (int)EmployeeComboBox.SelectedValue,
                    OrderDate = OrderDatePicker.SelectedDate ?? DateTime.Now
                };

                orderRepo.Add(order);

                foreach (var detail in _orderDetails)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderID = newOrderId,
                        ProductID = detail.ProductID,
                        UnitPrice = detail.UnitPrice,
                        Quantity = detail.Quantity,
                        Discount = detail.Discount
                    };
                    orderDetailRepo.Add(orderDetail);
                }

                MessageBox.Show("Tạo đơn hàng thành công");
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

    public class OrderDetailItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = "";
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public decimal Total { get; set; }
    }
}
