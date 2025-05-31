using SoftwareAccounting.Common.Models.Poeple;
using SoftwareAccounting.Service.Services.ApiClient;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        private readonly ISoftwareAccountingApiClient _apiClient;

        public PeopleService(ISoftwareAccountingApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Employer>> GetEmployers()
        {
            var response = await _apiClient.GetAllEmployers();
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }

        public async Task<List<User>> GetUsers()
        {
            var response = await _apiClient.GetAllUsers();
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }
    }
}
