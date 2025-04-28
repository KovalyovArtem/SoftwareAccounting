using SoftwareAccounting.Common.Models.RegisterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Domain.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountModel> GetAccountByUserName(string userName);

        Task<bool> IsUserNameExist(string userName);

        Task<bool> RegisterUser(AccountModel model);
    }
}
