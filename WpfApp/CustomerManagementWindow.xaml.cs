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
using BusinessObjects;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        private CustomerRepository _customerRepo;

        public CustomerManagementWindow()
        {
            InitializeComponent();
            _customerRepo = new CustomerRepository();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            CustomerGrid.ItemsSource = _customerRepo.GetAll();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadCustomers();
            }
            else
            {
                var filtered = _customerRepo.GetAll()
                    .Where(c => c.CompanyName.Contains(searchText, System.StringComparison.OrdinalIgnoreCase) ||
                               c.ContactName.Contains(searchText, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
                CustomerGrid.ItemsSource = filtered;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var popup = new AddEditCustomerWindow();
            if (popup.ShowDialog() == true)
            {
                var allCustomers = _customerRepo.GetAll().ToList();
                var maxId = allCustomers.Count > 0 ? allCustomers.Max(c => c.CustomerID) : 0;
                popup.Customer.CustomerID = maxId + 1;

                _customerRepo.Add(popup.Customer);
                LoadCustomers();
                MessageBox.Show("Thêm khách hàng thành công");
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem is Customer selectedCustomer)
            {
                var popup = new AddEditCustomerWindow(selectedCustomer);
                if (popup.ShowDialog() == true)
                {
                    _customerRepo.Update(popup.Customer);
                    LoadCustomers();
                    MessageBox.Show("Cập nhật khách hàng thành công");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem is Customer selectedCustomer)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _customerRepo.Delete(selectedCustomer.CustomerID);
                    LoadCustomers();
                    MessageBox.Show("Xóa khách hàng thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
            }
        }
    }
}