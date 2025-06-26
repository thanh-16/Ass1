using BusinessObjects;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        IEnumerable<Customer> Search(string keyword);
    }
}