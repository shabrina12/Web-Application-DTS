using WebApplicationDTS.Models;

namespace WebApplicationDTS.Repository.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
        string GetFullName(string email);
    }
}
