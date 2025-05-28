using SoftwareAccounting.Common.Models.AuthModel;
using SoftwareAccounting.Service.Services.ApiClient;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ISoftwareAccountingApiClient _apiClient;

        public AuthService(
            ISoftwareAccountingApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<string> AuthenticateAsync(RegisterUserRequest model)
        {
            var response = await _apiClient.Login(model);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return "Unauthorized";

            return response.Content;
        }
    }
}
