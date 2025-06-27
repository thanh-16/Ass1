using System.Collections.Generic;
using System.Windows;

namespace WpfApp
{
    public partial class OrderDetailPopupWindow : Window
    {
        public OrderDetailPopupWindow(IEnumerable<object> details)
        {
            InitializeComponent();
            OrderDetailGrid.ItemsSource = details;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}