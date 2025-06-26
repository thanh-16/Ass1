using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public sealed class SaleDbContext
    {
        private static readonly SaleDbContext instance = new SaleDbContext();
        public static SaleDbContext Instance => instance;

        public List<Employee> Employees { get; private set; }
        public List<Customer> Customers { get; private set; }
        public List<Product> Products { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Order> Orders { get; private set; }
        public List<OrderDetail> OrderDetails { get; private set; }

        private SaleDbContext()
        {
            // !!! QUAN TRỌNG: Bạn phải tự nạp dữ liệu mẫu từ file .sql vào các List này
            Employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, Name = "Thành", UserName = "thanh", Password = "123", JobTitle = "Sales" },
                new Employee { EmployeeID = 2, Name = "Thành 2", UserName = "thanh", Password = "456", JobTitle = "sales2" },
                // ... Thêm các employee khác
            };

            Customers = new List<Customer>(); // Tự nạp dữ liệu Customer
            Products = new List<Product>();   // Tự nạp dữ liệu Product
            Categories = new List<Category>(); // Tự nạp dữ liệu Category
            Orders = new List<Order>();       // Tự nạp dữ liệu Order
            OrderDetails = new List<OrderDetail>(); // Tự nạp dữ liệu OrderDetail
        }
    }
}