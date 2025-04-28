using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.RegisterModels;
using SoftwareAccounting.Domain.Models;
using SoftwareAccounting.Domain.Repositories.Interfaces;

namespace SoftwareAccounting.Domain.Repositories.Implementations
{
    public class DevicesRepository : IDevicesRepository
    {
        private readonly NpgsqlDataSource _dataSource;
        private readonly ILogger<DevicesRepository> _logger;
        private readonly IOptions<AppSettings> _settings;

        public DevicesRepository(
            NpgsqlDataSource dataSource,
            ILogger<DevicesRepository> logger,
            IOptions<AppSettings> settings)
        {
            _dataSource = dataSource;
            _logger = logger;
            _settings = settings;
        }

        public async Task<List<DeviceInfoModel>> GetDevicesAsync()
        {
            #region SQL

            var sql = @"

SELECT d.id AS Id,
	   d.sotr AS Sotr,
	   d.ip_address AS IpAddress,
	   d.mac_address AS MacAddress,
	   d.is_active AS IsActive,
	   d.os_name AS OsName,
	   d.os_architecture AS OsArchitecture
FROM mir.device d

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var res = await dbConnection.QueryAsync<DeviceInfoModel>(sql);
                return res.ToList();
            }
        }

        public async Task<DeviceExtensionInfoModel> GetDeviceInfoAsync(Guid id)
        {
            #region SQL

            var sql = @"



";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var res = await dbConnection.QueryFirstOrDefaultAsync<DeviceExtensionInfoModel>(sql);
                return res;
            }
        }
    }
}
