using BusinessObjects;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        IEnumerable<OrderDetail> GetByOrderId(int orderId);
        void Add(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Delete(int orderId, int productId);
    }
}