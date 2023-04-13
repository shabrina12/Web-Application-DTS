using WebApplicationDTS.Contexts;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Repository
{
    public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
    {
       public UniversityRepository(MyContext context) : base(context) { }

    }
}
