using SoftwareAccounting.Common.Models.RegisterModels;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(AccountModel model);
    }
}
