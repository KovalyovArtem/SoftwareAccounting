using SoftwareAccounting.Common.Models.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(RegisterUserRequest model);
    }
}
