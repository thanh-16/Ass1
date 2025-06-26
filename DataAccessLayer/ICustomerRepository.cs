using BusinessObjects;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerByPhone(string phone);
    }
}