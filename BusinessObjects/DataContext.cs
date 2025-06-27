using System;
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
            Customers = new List<Customer>
            {
                new Customer
                {
                    CustomerID = 1,
                    CompanyName = "Công ty ABC",
                    ContactName = "Nguyễn Văn A",
                    ContactTitle = "Giám đốc",
                    Address = "123 Đường A, Quận 1, TP.HCM",
                    Phone = "0123456789"
                },
                new Customer
                {
                    CustomerID = 2,
                    CompanyName = "Công ty X",
                    ContactName = "Trần Thị B",
                    ContactTitle = "Trưởng phòng",
                    Address = "456 Đường B, Quận 3, TP.HCM",
                    Phone = "1234567890"
                },
                new Customer
                {
                    CustomerID = 3,
                    CompanyName = "Công ty D",
                    ContactName = "Lê Văn C",
                    ContactTitle = "Giám đốc",
                    Address = "789 Đường C, Quận 5, TP.HCM",
                    Phone = "0987654321"
                }
            };

            Employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    Name = "Admin",
                    UserName = "admin",
                    Password = "admin",
                    JobTitle = "Administrator",
                    Phone = "0123456789"
                },
                new Employee
                {
                    EmployeeID = 2,
                    Name = "Nhân viên",
                    UserName = "nhanvien",
                    Password = "12345",
                    JobTitle = "Nhân viên",
                    Phone = "0987654321"
                },
                new Employee
                {
                    EmployeeID = 3,
                    Name = "Quản lý",
                    UserName = "quanly",
                    Password = "123",
                    JobTitle = "Quản lý",
                    Phone = "0912345678"
                }
            };

            Categories = new List<Category>
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Đồ uống",
                    Description = "Các loại nước giải khát"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Thực phẩm",
                    Description = "Đồ ăn nhanh"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Tráng miệng",
                    Description = "Các món tráng miệng"
                }
            };

            Products = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Cà phê sữa",
                    CategoryID = 1,
                    UnitPrice = 25000,
                    UnitsInStock = 100,
                    Description = "Cà phê sữa đá"
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Bánh mì",
                    CategoryID = 2,
                    UnitPrice = 15000,
                    UnitsInStock = 50,
                    Description = "Bánh mì thịt"
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Trà sữa",
                    CategoryID = 1,
                    UnitPrice = 30000,
                    UnitsInStock = 80,
                    Description = "Trà sữa trân châu"
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Kem",
                    CategoryID = 3,
                    UnitPrice = 20000,
                    UnitsInStock = 60,
                    Description = "Kem vani"
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Nước cam",
                    CategoryID = 1,
                    UnitPrice = 18000,
                    UnitsInStock = 90,
                    Description = "Nước cam tươi"
                }
            };

            Orders = new List<Order>
            {
                // Cus 1
                new Order
                {
                    OrderID = 1,
                    CustomerID = 1,
                    EmployeeID = 2,
                    OrderDate = new DateTime(2024, 6, 1)
                },
                new Order
                {
                    OrderID = 2,
                    CustomerID = 1,
                    EmployeeID = 1,
                    OrderDate = new DateTime(2024, 6, 5)
                },
                new Order
                {
                    OrderID = 3,
                    CustomerID = 1,
                    EmployeeID = 3,
                    OrderDate = new DateTime(2024, 6, 10)
                },
                new Order
                {
                    OrderID = 4,
                    CustomerID = 1,
                    EmployeeID = 2,
                    OrderDate = new DateTime(2024, 6, 15)
                },
                
                // Cus 2 
                new Order
                {
                    OrderID = 5,
                    CustomerID = 2,
                    EmployeeID = 1,
                    OrderDate = new DateTime(2024, 6, 3)
                },
                new Order
                {
                    OrderID = 6,
                    CustomerID = 2,
                    EmployeeID = 3,
                    OrderDate = new DateTime(2024, 6, 8)
                },
                new Order
                {
                    OrderID = 7,
                    CustomerID = 2,
                    EmployeeID = 2,
                    OrderDate = new DateTime(2024, 6, 12)
                },
                
                // Cus 3
                new Order
                {
                    OrderID = 8,
                    CustomerID = 3,
                    EmployeeID = 1,
                    OrderDate = new DateTime(2024, 6, 4)
                },
                new Order
                {
                    OrderID = 9,
                    CustomerID = 3,
                    EmployeeID = 2,
                    OrderDate = new DateTime(2024, 6, 9)
                },
                new Order
                {
                    OrderID = 10,
                    CustomerID = 3,
                    EmployeeID = 3,
                    OrderDate = new DateTime(2024, 6, 14)
                }
            };

            OrderDetails = new List<OrderDetail>
            {
                //OrderId 1
                new OrderDetail { OrderID = 1, ProductID = 1, UnitPrice = 25000, Quantity = 2, Discount = 0 },
                new OrderDetail { OrderID = 1, ProductID = 2, UnitPrice = 15000, Quantity = 1, Discount = 0.1f },

                new OrderDetail { OrderID = 2, ProductID = 3, UnitPrice = 30000, Quantity = 2, Discount = 0 },
                new OrderDetail { OrderID = 2, ProductID = 4, UnitPrice = 20000, Quantity = 1, Discount = 0.05f },
                
                new OrderDetail { OrderID = 3, ProductID = 1, UnitPrice = 25000, Quantity = 1, Discount = 0 },
                new OrderDetail { OrderID = 3, ProductID = 5, UnitPrice = 18000, Quantity = 3, Discount = 0.15f },

                new OrderDetail { OrderID = 4, ProductID = 2, UnitPrice = 15000, Quantity = 2, Discount = 0 },
                new OrderDetail { OrderID = 4, ProductID = 3, UnitPrice = 30000, Quantity = 1, Discount = 0.1f },

                new OrderDetail { OrderID = 5, ProductID = 4, UnitPrice = 20000, Quantity = 3, Discount = 0 },
                new OrderDetail { OrderID = 5, ProductID = 1, UnitPrice = 25000, Quantity = 1, Discount = 0.2f },

                new OrderDetail { OrderID = 6, ProductID = 5, UnitPrice = 18000, Quantity = 2, Discount = 0 },
                new OrderDetail { OrderID = 6, ProductID = 2, UnitPrice = 15000, Quantity = 2, Discount = 0.1f },

                new OrderDetail { OrderID = 7, ProductID = 3, UnitPrice = 30000, Quantity = 1, Discount = 0 },
                new OrderDetail { OrderID = 7, ProductID = 4, UnitPrice = 20000, Quantity = 2, Discount = 0.05f },

                new OrderDetail { OrderID = 8, ProductID = 1, UnitPrice = 25000, Quantity = 3, Discount = 0 },
                new OrderDetail { OrderID = 8, ProductID = 5, UnitPrice = 18000, Quantity = 1, Discount = 0.1f },

                new OrderDetail { OrderID = 9, ProductID = 2, UnitPrice = 15000, Quantity = 2, Discount = 0 },
                new OrderDetail { OrderID = 9, ProductID = 3, UnitPrice = 30000, Quantity = 2, Discount = 0.15f },

                new OrderDetail { OrderID = 10, ProductID = 4, UnitPrice = 20000, Quantity = 1, Discount = 0 },
                new OrderDetail { OrderID = 10, ProductID = 1, UnitPrice = 25000, Quantity = 2, Discount = 0.2f }
            };
        }
    }
}