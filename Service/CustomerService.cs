using BusinessObjects;
using DataAccessLayer;
using System.Collections.Generic;

namespace Service
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public Customer GetCustomerByPhone(string phone) => _customerRepository.GetCustomerByPhone(phone);
        public List<Customer> GetCustomers() => _customerRepository.GetCustomers();
    }
}