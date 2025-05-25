using Refit;
using SoftwareAccounting.Admin.UI.Forms;
using SoftwareAccounting.Service.Services.ApiClient;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;
using System.Windows.Forms;

namespace SoftwareAccounting.Admin.UI
{
    internal static class Program
    {
        public static ISoftwareAccountingApiClient apiClient { get; private set; }
        public static IDeviceService deviceService { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            apiClient = CreateApiClient("http://192.168.31.109:5080");

            deviceService = new DeviceService(apiClient);

            Application.Run(new LoginForm());
        }

        private static ISoftwareAccountingApiClient CreateApiClient(string baseUrl)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = new TimeSpan(0, 2, 0)
            };

            return RestService.For<ISoftwareAccountingApiClient>(httpClient);
        }
    }
}