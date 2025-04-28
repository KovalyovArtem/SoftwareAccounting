using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Domain.Repositories.Implementations
{
    public class IntegrationDeviceRepository : IIntegrationDeviceRepository
    {
        private readonly NpgsqlDataSource _dataSource;
        private readonly ILogger<IntegrationDeviceRepository> _logger;
        private readonly IOptions<AppSettings> _settings;

        public IntegrationDeviceRepository(
            NpgsqlDataSource dataSource,
            ILogger<IntegrationDeviceRepository> logger,
            IOptions<AppSettings> settings)
        {
            _logger = logger;
            _settings = settings;

            _dataSource = dataSource;
        }
    }
}
