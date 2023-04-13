using WebApplicationDTS.Models;
using WebApplicationDTS.ViewModels;

namespace WebApplicationDTS.Repository.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account, string>
    {
        int Register(RegisterVM registerVM);
        bool Login(LoginVM loginVM);
		UserVM GetUser(string email);
	}
}
