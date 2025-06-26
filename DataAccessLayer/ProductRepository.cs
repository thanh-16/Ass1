using BusinessObjects;

namespace DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {
            products = DataContext.Instance.Products;
        }

        public IEnumerable<Product> GetAll() => products;

        public Product? GetById(int id) => products.FirstOrDefault(p => p.ProductID == id);

        public void Add(Product product) => products.Add(product);

        public void Update(Product product)
        {
            var existing = GetById(product.ProductID);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.CategoryID = product.CategoryID;
                existing.UnitPrice = product.UnitPrice;
                existing.UnitsInStock = product.UnitsInStock;
                existing.Description = product.Description;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null) products.Remove(product);
        }

        public IEnumerable<Product> Search(string keyword) =>
            products.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }
}