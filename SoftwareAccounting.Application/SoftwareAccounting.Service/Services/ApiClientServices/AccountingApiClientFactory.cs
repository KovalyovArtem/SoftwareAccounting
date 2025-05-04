using Refit;

namespace SoftwareAccounting.Service.Services.ApiClientServices
{
    public class AccountingApiClientFactory : IAccountingApiClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountingApiClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IAccountingApiClient CreateClient(string baseUrl)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            return RestService.For<IAccountingApiClient>(httpClient);
        }
    }
}