using WebApplicationDTS.Contexts;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Repository
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int, MyContext>, IAccountRoleRepository
    {
        public AccountRoleRepository(MyContext context) : base(context) { }
    }
}
