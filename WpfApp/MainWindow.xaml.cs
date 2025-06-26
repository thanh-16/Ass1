using System.Windows;
using WpfApp.ViewModels;
using Service;
using DataAccessLayer;
using BusinessObjects;

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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(OrderIdBox.Text, out int orderId) &&
                int.TryParse(ProductIdBox.Text, out int productId) &&
                decimal.TryParse(UnitPriceBox.Text, out decimal unitPrice) &&
                int.TryParse(QuantityBox.Text, out int quantity) &&
                float.TryParse(DiscountBox.Text, out float discount))
            {
                var detail = new OrderDetail
                {
                    OrderID = orderId,
                    ProductID = productId,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Discount = discount
                };
                OrderDetailVM.Add(detail);
            }
            else
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrderDetailGrid.SelectedItem is OrderDetail selected)
            {
                OrderDetailVM.Delete(selected);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (OrderDetailGrid.SelectedItem is OrderDetail selected &&
                int.TryParse(OrderIdBox.Text, out int orderId) &&
                int.TryParse(ProductIdBox.Text, out int productId) &&
                decimal.TryParse(UnitPriceBox.Text, out decimal unitPrice) &&
                int.TryParse(QuantityBox.Text, out int quantity) &&
                float.TryParse(DiscountBox.Text, out float discount))
            {
                selected.OrderID = orderId;
                selected.ProductID = productId;
                selected.UnitPrice = unitPrice;
                selected.Quantity = quantity;
                selected.Discount = discount;
                OrderDetailVM.Update(selected);
                OrderDetailGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Invalid input or no item selected!");
            }
        }

    }
}