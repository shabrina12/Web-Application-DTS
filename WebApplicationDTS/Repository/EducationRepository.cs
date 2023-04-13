using WebApplicationDTS.Contexts;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Repository
{
    public class EducationRepository : GeneralRepository<Education, int, MyContext>, IEducationRepository
    {       
        public EducationRepository(MyContext context) : base(context) { }

    }
}
