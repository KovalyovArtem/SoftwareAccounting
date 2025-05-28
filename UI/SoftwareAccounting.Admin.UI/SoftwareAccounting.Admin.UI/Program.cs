using Microsoft.VisualBasic.ApplicationServices;
using Refit;
using SoftwareAccounting.Admin.UI.Forms;
using SoftwareAccounting.Common.Models.AuthModel;
using SoftwareAccounting.Service.Services.ApiClient;
using SoftwareAccounting.Service.Services.ApiClient.RefitHandler;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;
using System.Windows.Forms;

namespace SoftwareAccounting.Admin.UI
{
    internal static class Program
    {
        public static ISoftwareAccountingApiClient apiClient { get; private set; }
        public static IDeviceService deviceService { get; private set; }

        public static IAuthService authService { get; private set; }

        public static bool runApplication = true;

        private static readonly string _baseUrl = "http://192.168.31.109:5080";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            apiClient = CreateApiClient(_baseUrl);

            deviceService = new DeviceService(apiClient);

            authService = new AuthService(apiClient);

            while (runApplication)
            {
                LoginForm frmLog = new LoginForm();
                Application.Run(frmLog);
                if (frmLog.IsLoggedIn)
                    Application.Run(new MainForm());
            }
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

        public static void SetAuthRefitHandler(AuthState authState)
        {
            var httpHandler = new AuthenticatedHttpClientHandler(authState, () => RefreshTokenAsync(authState))
            {
                InnerHandler = new HttpClientHandler()
            };

            var httpClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri(_baseUrl),
                Timeout = new TimeSpan(0, 2, 0)
            };

            apiClient = RestService.For<ISoftwareAccountingApiClient>(httpClient);
            authService = new AuthService(apiClient);
            deviceService = new DeviceService(apiClient);
        }

        private static async Task<bool> RefreshTokenAsync(AuthState authState)
        {
            try
            {
                var credentials = new RegisterUserRequest { UserName = authState.Username, Password = authState.Password };
                var loginResponse = await authService.AuthenticateAsync(credentials);

                authState.AccessToken = loginResponse;
                authState.RefreshToken = loginResponse;

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}