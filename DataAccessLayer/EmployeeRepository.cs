using BusinessObjects;
using System.Linq;

namespace DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SaleDbContext _context = SaleDbContext.Instance;
        public Employee Authenticate(string username, string password)
        {
            return _context.Employees.FirstOrDefault(e => e.UserName.Equals(username) && e.Password.Equals(password));
        }
    }
}