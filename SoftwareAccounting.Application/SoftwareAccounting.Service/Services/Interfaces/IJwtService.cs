using SoftwareAccounting.Common.Models.RegisterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(AccountModel model);
    }
}
