using BusinessObjects;
using DataAccessLayer;
using System.Collections.Generic;

namespace Service
{
    public class OrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetail> GetAll() => _orderDetailRepository.GetAll();

        public IEnumerable<OrderDetail> GetByOrderId(int orderId) => _orderDetailRepository.GetByOrderId(orderId);

        public void Add(OrderDetail orderDetail) => _orderDetailRepository.Add(orderDetail);

        public void Update(OrderDetail orderDetail) => _orderDetailRepository.Update(orderDetail);

        public void Delete(int orderId, int productId) => _orderDetailRepository.Delete(orderId, productId);
    }
}