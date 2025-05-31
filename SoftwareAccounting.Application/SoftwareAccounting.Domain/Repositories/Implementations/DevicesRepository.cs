using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.IntegrationModels;
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

        public async Task<List<DeviceSettingsInfoModel>> GetDevicesAsync()
        {
            #region SQL

            var sql = @"

SELECT d.id AS Id,
	   d.sotr AS Sotr,
	   s.surname || ' ' || s.name || ' ' || COALESCE(s.patronymic, '') AS SotrFullName,
	   d.synonym AS Synonym,
	   d.ip_address AS IpAddress,
	   d.mac_address AS MacAddress,
	   d.is_active AS IsActive,
	   d.os_name AS OsName,
	   d.os_architecture AS OsArchitecture
FROM mir.device d
LEFT JOIN mir.sotr s ON s.id = d.sotr

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var res = await dbConnection.QueryAsync<DeviceSettingsInfoModel>(sql);
                return res.ToList();
            }
        }

        public async Task<DeviceSettingsInfoModel> GetDeviceByIdAsync(Guid deviceId)
        {
            #region SQL

            var sql = @"

SELECT d.id AS Id,
	   d.sotr AS Sotr,
	   s.surname || ' ' || s.name || ' ' || COALESCE(s.patronymic, '') AS SotrFullName,
	   d.synonym AS Synonym,
	   d.ip_address AS IpAddress,
	   d.mac_address AS MacAddress,
	   d.is_active AS IsActive,
	   d.os_name AS OsName,
	   d.os_architecture AS OsArchitecture
FROM mir.device d
LEFT JOIN mir.sotr s ON s.id = d.sotr
WHERE d.id = @deviceId
LIMIT 1

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var param = new { deviceId };
                var res = await dbConnection.QueryFirstOrDefaultAsync<DeviceSettingsInfoModel>(sql, param);
                return res;
            }
        }

        public async Task<List<SoftwareInfoModel>> GetSoftwareDeviceInfoAsync(Guid id)
        {
            #region SQL

            var sql = @"

SELECT s.id AS Id,
	   s.name AS ProgrammName,
	   s.version AS ProgrammVersion,
	   s.developer AS ProgrammDeveloper,
	   s.license AS ProgrammLicense,
	   s.installed_date AS ProgrammInstalledDate,
	   s.size AS ProgrammSize,
	   s.install_location AS ProgrammInstallLocation,
	   s.publisher AS ProgrammPublisher
FROM mir.software s 
WHERE s.device_id = @id

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var param = new
                {
                    id
                };
                var res = await dbConnection.QueryAsync<SoftwareInfoModel>(sql, param);
                return res.ToList();
            }
        }

        public async Task<string?> GetDeviceIpAddressByIdAsync(Guid deviceId)
        {
            #region SQL

            var sql = @"

SELECT d.ip_address AS IpAddress
FROM mir.device d
WHERE d.id = @deviceId
LIMIT 1

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var param = new { deviceId };
                var res = await dbConnection.QueryFirstOrDefaultAsync<string>(sql, param);
                return res;
            }
        }
    }
}
