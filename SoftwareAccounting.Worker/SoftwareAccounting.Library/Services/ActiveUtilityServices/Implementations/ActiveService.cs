using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Library.Services.ActiveUtilityServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Library.Services.ActiveUtilityServices.Implementations
{
    public class ActiveService : IActiveService
    {
        private readonly ILogger<ActiveService> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public ActiveService(ILogger<ActiveService> logger,
                             IOptions<AppSettings> appSettings)
        {
            logger = _logger;
            _appSettings = appSettings;
        }

        public async Task<bool> SendInfoAboutDeviceIsActive()
        {
            return false;
        }
    }
}
