using BusinessObjects;

namespace DataAccessLayer
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly List<OrderDetail> orderDetails;

        public OrderDetailRepository()
        {
            orderDetails = DataContext.Instance.OrderDetails;
        }

        public IEnumerable<OrderDetail> GetAll() => orderDetails;

        public IEnumerable<OrderDetail> GetByOrderId(int orderId) =>
            orderDetails.Where(od => od.OrderID == orderId);

        public void Add(OrderDetail orderDetail) => orderDetails.Add(orderDetail);

        public void Update(OrderDetail orderDetail)
        {
            var existing = orderDetails.FirstOrDefault(od =>
                od.OrderID == orderDetail.OrderID && od.ProductID == orderDetail.ProductID);
            if (existing != null)
            {
                existing.UnitPrice = orderDetail.UnitPrice;
                existing.Quantity = orderDetail.Quantity;
                existing.Discount = orderDetail.Discount;
            }
        }

        public void Delete(int orderId, int productId)
        {
            var orderDetail = orderDetails.FirstOrDefault(od =>
                od.OrderID == orderId && od.ProductID == productId);
            if (orderDetail != null) orderDetails.Remove(orderDetail);
        }
    }
}