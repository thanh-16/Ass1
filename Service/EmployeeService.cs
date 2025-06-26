using BusinessObjects;
using DataAccessLayer;

namespace Service
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public Employee Authenticate(string username, string password)
        {
            return _employeeRepository.Authenticate(username, password);
        }
    }
}