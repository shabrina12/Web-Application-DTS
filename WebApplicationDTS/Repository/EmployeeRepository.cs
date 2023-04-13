using WebApplicationDTS.Contexts;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Repository
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context) { }
        public string GetFullName(string email)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                return String.Empty;
            }
            return employee.FirstName + " " + employee.LastName;            
        }
    }
}
