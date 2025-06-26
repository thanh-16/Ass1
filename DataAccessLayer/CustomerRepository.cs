using BusinessObjects;

namespace DataAccessLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers;

        public CustomerRepository()
        {
            customers = DataContext.Instance.Customers;
        }

        public IEnumerable<Customer> GetAll() => customers;

        public Customer? GetById(int id) => customers.FirstOrDefault(c => c.CustomerID == id);

        public void Add(Customer customer) => customers.Add(customer);

        public void Update(Customer customer)
        {
            var existing = GetById(customer.CustomerID);
            if (existing != null)
            {
                existing.CompanyName = customer.CompanyName;
                existing.ContactName = customer.ContactName;
                existing.ContactTitle = customer.ContactTitle;
                existing.Address = customer.Address;
                existing.Phone = customer.Phone;
            }
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null) customers.Remove(customer);
        }

        public IEnumerable<Customer> Search(string keyword) =>
            customers.Where(c => c.CompanyName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }
}