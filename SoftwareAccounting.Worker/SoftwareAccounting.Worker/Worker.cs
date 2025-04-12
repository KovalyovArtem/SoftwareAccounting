using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SoftwareAccounting.Library.Services.ActiveUtilityServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Worker
{
    public class Worker(IServiceProvider serviceProvider) : BackgroundService
    {
        private bool _requestIsSuccessful = false;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                using var scope = serviceProvider.CreateScope();
                var _logger = scope.ServiceProvider.GetService<ILogger<Worker>>();
                var _activeService = scope.ServiceProvider.GetService<IActiveService>();

                try
                {
                    _requestIsSuccessful = await _activeService.SendInfoAboutDeviceIsActive();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                await Task.Delay(new TimeSpan(0, 4, 0));
            }
        }
    }
}
