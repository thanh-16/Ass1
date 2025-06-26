using BusinessObjects;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        Employee? GetByUserName(string username);
    }
}