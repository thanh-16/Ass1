using BusinessObjects;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order? GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}