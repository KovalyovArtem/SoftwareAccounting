using SoftwareAccounting.Common.Models.RegisterModels;

namespace SoftwareAccounting.Domain.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountModel> GetAccountByUserName(string userName);

        Task<bool> IsUserNameExist(string userName);

        Task<bool> RegisterUser(AccountModel model);
    }
}
