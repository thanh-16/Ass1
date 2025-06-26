using BusinessObjects;

namespace DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders;

        public OrderRepository()
        {
            orders = DataContext.Instance.Orders;
        }

        public IEnumerable<Order> GetAll() => orders;

        public Order? GetById(int id) => orders.FirstOrDefault(o => o.OrderID == id);

        public void Add(Order order) => orders.Add(order);

        public void Update(Order order)
        {
            var existing = GetById(order.OrderID);
            if (existing != null)
            {
                existing.CustomerID = order.CustomerID;
                existing.EmployeeID = order.EmployeeID;
                existing.OrderDate = order.OrderDate;
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null) orders.Remove(order);
        }
    }
}