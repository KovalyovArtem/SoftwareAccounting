using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.ApiClientServices
{
    public interface IAccountingApiClientFactory
    {
        IAccountingApiClient CreateClient(string baseUrl);
    }
}
