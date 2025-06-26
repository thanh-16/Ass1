using BusinessObjects;
namespace DataAccessLayer
{
    public interface IEmployeeRepository
    {
        Employee Authenticate(string username, string password);
    }
}