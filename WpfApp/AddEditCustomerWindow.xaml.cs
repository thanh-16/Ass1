using System.Windows;
using BusinessObjects;

namespace WpfApp
{
    public partial class AddEditCustomerWindow : Window
    {
        public Customer Customer { get; private set; }
        public AddEditCustomerWindow(Customer? customer = null)
        {
            InitializeComponent();
            if (customer != null)
            {
                Customer = new Customer
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    Phone = customer.Phone
                };
                CompanyNameBox.Text = Customer.CompanyName;
                ContactNameBox.Text = Customer.ContactName;
                ContactTitleBox.Text = Customer.ContactTitle;
                AddressBox.Text = Customer.Address;
                PhoneBox.Text = Customer.Phone;
            }
            else
            {
                Customer = new Customer();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Simple validation
            if (string.IsNullOrWhiteSpace(CompanyNameBox.Text) || string.IsNullOrWhiteSpace(PhoneBox.Text))
            {
                MessageBox.Show("Tên công ty và Số điện thoại không được để trống!");
                return;
            }
            Customer.CompanyName = CompanyNameBox.Text;
            Customer.ContactName = ContactNameBox.Text;
            Customer.ContactTitle = ContactTitleBox.Text;
            Customer.Address = AddressBox.Text;
            Customer.Phone = PhoneBox.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}