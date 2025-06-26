using BusinessLogicLayer;
using BusinessObjects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly ProductService _productService;
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products { get => _products; set { _products = value; OnPropertyChanged(); } }

        public ProductViewModel()
        {
            _productService = new ProductService();
            LoadData(null);
        }

        private void LoadData(object obj)
        {
            Products = new ObservableCollection<Product>(_productService.GetProducts());
        }

        // TODO: Thêm các Command và phương thức cho Add, Update, Delete, Search sản phẩm tương tự như CustomerViewModel
    }
}