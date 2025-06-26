using System.Collections.Generic;

namespace BusinessObjects
{
    public class DataContext
    {
        private static DataContext? _instance;
        public static DataContext Instance => _instance ??= new DataContext();

        public List<Customer> Customers { get; }
        public List<Employee> Employees { get; }
        public List<Category> Categories { get; }
        public List<Product> Products { get; }
        public List<Order> Orders { get; }
        public List<OrderDetail> OrderDetails { get; }

        private DataContext()
        {
            Customers = new List<Customer>();
            Employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    Name = "Admin",
                    UserName = "admin",
                    Password = "admin123",
                    JobTitle = "Administrator",
                    Phone = "0123456789"
                }
            };
            Categories = new List<Category>();
            Products = new List<Product>();
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
        }
    }
}