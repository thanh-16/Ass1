using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SaleDbContext _context = SaleDbContext.Instance;
        public List<Customer> GetCustomers() => _context.Customers;
        public Customer GetCustomerByPhone(string phone) => _context.Customers.FirstOrDefault(c => c.Phone.Equals(phone, StringComparison.OrdinalIgnoreCase));
    }
}