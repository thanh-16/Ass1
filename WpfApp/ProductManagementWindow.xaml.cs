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
    /// Interaction logic for ProductManagementWindow.xaml
    /// </summary>
    public partial class ProductManagementWindow : Window
    {
        private ProductRepository _productRepo;

        public ProductManagementWindow()
        {
            InitializeComponent();
            _productRepo = new ProductRepository();
            LoadProducts();
        }

        private void LoadProducts()
        {
            ProductGrid.ItemsSource = _productRepo.GetAll();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadProducts();
            }
            else
            {
                var filtered = _productRepo.GetAll()
                    .Where(p => p.ProductName.Contains(searchText, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
                ProductGrid.ItemsSource = filtered;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng thêm sản phẩm sẽ được thêm sau!");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng sửa sản phẩm sẽ được thêm sau!");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    _productRepo.Delete(selectedProduct.ProductID);
                    LoadProducts();
                    MessageBox.Show("Xóa sản phẩm thành công!");
                }
            }
            else
            {
                MessageBox.Show("chọn sản phẩm cần xóa!");
            }
        }
    }
}
