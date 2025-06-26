using BusinessObjects;

namespace DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees;

        public EmployeeRepository()
        {
            employees = DataContext.Instance.Employees;
        }

        public IEnumerable<Employee> GetAll() => employees;

        public Employee? GetById(int id) => employees.FirstOrDefault(e => e.EmployeeID == id);

        public void Add(Employee employee) => employees.Add(employee);

        public void Update(Employee employee)
        {
            var existing = GetById(employee.EmployeeID);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.UserName = employee.UserName;
                existing.Password = employee.Password;
                existing.JobTitle = employee.JobTitle;
                existing.Phone = employee.Phone;
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null) employees.Remove(employee);
        }

        public Employee? GetByUserName(string username) =>
            employees.FirstOrDefault(e => e.UserName == username);
    }
}