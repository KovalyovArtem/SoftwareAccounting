using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.IntegrationModels;
using SoftwareAccounting.Domain.Extensions;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public async Task<List<string>> GetAllActiveDeviceIp()
        {
            #region SQL

            var sql = @"

SELECT d.ip_address AS IpAddress
FROM mir.device d
WHERE d.is_active = TRUE
  AND d.ip_address IS NOT NULL

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var res = await dbConnection.QueryAsync<string>(sql);
                return res.ToList();
            }
        }

        public async Task<Guid> GetDeviceIdByIpAddress(string ipAddress)
        {
            #region SQL

            var sql = @"

SELECT id
FROM mir.device 
WHERE ip_address = @ip_address
LIMIT 1

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var param = new
                {
                    ip_address = ipAddress
                };
                var res = await dbConnection.QueryFirstOrDefaultAsync<Guid>(sql, param);
                return res;
            }
        }

        public async Task<bool> ClearDeviceInfotables(Guid deviceId)
        {
            #region SQL

            var sql = @"

DELETE FROM mir.software 
WHERE device_id = @device_id;

DELETE FROM mir.device_param 
WHERE device_id = @device_id;

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var transaction = await dbConnection.BeginTransactionLogAsync(_settings.Value.IsLog);

                try
                {
                    var param = new
                    {
                        device_id = deviceId
                    };
                    await dbConnection.ExecuteAsync(sql, param, transaction);
                    transaction.Commit();

                    _logger.LogInformation($"Данные приложений и доп значений для устройства с id: {deviceId} успешно обработаны!");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogInformation(e, $"Ошибка при обработке данных приложений и доп значений для устройства с id: {deviceId}:\n{e.Message}");
                    return false;
                }

                return true;
            }
        }

        public async Task<bool> InsertSoftwareDeviceInfo(Guid deviceId, SoftwareInfoModel model)
        {
            #region SQL

            var sql = @"

INSERT INTO mir.software (device_id, name, version, developer, license, installed_date, size, install_location, publisher)
	SELECT @device_id, @name, @version, @developer, @license, @installed_date, @size, @install_location, @publisher;

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var transaction = await dbConnection.BeginTransactionLogAsync(_settings.Value.IsLog);

                try
                {
                    var param = new
                    {
                        device_id = deviceId,
                        name = model.ProgrammName,
                        version = model.ProgrammVersion,
                        developer = model.ProgrammDeveloper,
                        license = model.ProgrammLicense,
                        installed_date = model.ProgrammInstalledDate,
                        size = model.ProgrammSize,
                        install_location = model.ProgrammInstallLocation,
                        publisher = model.ProgrammPublisher,
                    };
                    await dbConnection.ExecuteAsync(sql, param, transaction);
                    transaction.Commit();

                    _logger.LogInformation($"Данные приложений для устройства с id: {deviceId} успешно обработаны!");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogInformation(e, $"Ошибка при обработке данных приложений для устройства с id: {deviceId}:\n{e.Message}");
                    return false;
                }

                return true;
            }
        }

        public async Task<bool> InsertHardwareDeviceInfo(Guid deviceId, HarwareInfoModel model)
        {
            #region SQL

            var sql = @"

INSERT INTO mir.device_param (device_id, name, value)
	SELECT @device_id, @name, @value;

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var transaction = await dbConnection.BeginTransactionLogAsync(_settings.Value.IsLog);

                try
                {
                    var param = new
                    {
                        device_id = deviceId,
                        name = model.Name,
                        value = model.Value
                    };
                    await dbConnection.ExecuteAsync(sql, param, transaction);
                    transaction.Commit();

                    _logger.LogInformation($"Данные доп значений для устройства с id: {deviceId} успешно обработаны!");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogInformation(e, $"Ошибка при обработке доп значений для устройства с id: {deviceId}:\n{e.Message}");
                    return false;
                }

                return true;
            }
        }

        public async Task<bool> RegisterDevice(DeviceSettingsModel model)
        {
            #region SQL

            var sql = @"

WITH exist_device_synonym AS (
	SELECT d.id AS id,
		   1 AS ord
	FROM mir.device d
	WHERE d.synonym = @synonym
	LIMIT 1
),
exist_device_default AS (
	SELECT d.id AS id,
		   2 AS ord
	FROM mir.device d
	WHERE d.ip_address = @ip_address 
	   OR d.mac_address = @mac_address
	LIMIT 1
),
device AS (
	SELECT t.id
	FROM (
		SELECT * 
		FROM exist_device_synonym s
			UNION ALL
		SELECT * 
		FROM exist_device_default d
	) t
	ORDER BY t.ord DESC 
	LIMIT 1
),
insert_new_device AS (
	INSERT INTO mir.device (ip_address, mac_address, is_active, os_name, os_architecture, synonym)
		SELECT @ip_address, @mac_address, TRUE, @os_name, @os_architecture, @synonym
		WHERE NOT EXISTS (SELECT 1 FROM device)
)
UPDATE mir.device 
   SET is_active = TRUE,
   	   ip_address = @ip_address,
   	   mac_address = @mac_address
 WHERE id = ( SELECT d.id FROM device d )
   AND EXISTS ( SELECT d.id FROM device d )

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var transaction = await dbConnection.BeginTransactionLogAsync(_settings.Value.IsLog);

                try
                {
                    var param = new
                    {
                        ip_address = model.DeviceIpAddress,
                        mac_address = model.DeviceMacAddress,
                        os_name = model.DeviceOS,
                        os_architecture = model.DeviceOSArchitecture,
                        synonym = model.DeviceSynonym
                    };
                    await dbConnection.ExecuteAsync(sql, param, transaction);
                    transaction.Commit();

                    _logger.LogInformation($"Устройство с синонимом: {model.DeviceSynonym ?? "Синоним отсутствует"} и ip: {model.DeviceIpAddress}, mac: {model.DeviceMacAddress} успешно обработан!");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogInformation(e, $"Ошибка при обработке устройства с синонимом: {model.DeviceSynonym ?? "Синоним отсутствует"} и ip: {model.DeviceIpAddress}, mac: {model.DeviceMacAddress}:\n{e.Message}");
                    return false;
                }

                return true;
            }
        }

        public async Task<bool> SetDeviceStatus(string ipAddress, string macAddress, string synonym, bool activeStatus)
        {
            #region SQL

            var sql = @"

WITH exist_device_synonym AS (
	SELECT d.id AS id,
		   1 AS ord
	FROM mir.device d
	WHERE d.synonym = @synonym
	   OR (
	   	 d.ip_address = @ip_address OR 
	   	 d.mac_address = @mac_address
	   )
	LIMIT 1
),
exist_device_default AS (
	SELECT d.id AS id,
		   2 AS ord
	FROM mir.device d
	WHERE d.ip_address = @ip_address 
	   OR d.mac_address = @mac_address
	LIMIT 1
),
device AS (
	SELECT t.id
	FROM (
		SELECT * 
		FROM exist_device_synonym s
			UNION ALL
		SELECT * 
		FROM exist_device_default d
	) t
	ORDER BY t.ord DESC 
	LIMIT 1
)
UPDATE mir.device 
   SET is_active = @status
 WHERE id = ( SELECT d.id FROM device d )
   AND EXISTS ( SELECT d.id FROM device d )

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var transaction = await dbConnection.BeginTransactionLogAsync(_settings.Value.IsLog);

                try
                {
                    var param = new
                    {
                        ip_address = ipAddress,
                        mac_address = macAddress,
                        synonym = synonym,
                        status = activeStatus
                    };
                    await dbConnection.ExecuteAsync(sql, param, transaction);
                    transaction.Commit();

                    _logger.LogInformation($"Статус устройства с синонимом: {synonym ?? "Синоним отсутствует"} и ip: {ipAddress}, mac: {macAddress} успешно выставлен!");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogInformation(e, $"Ошибка при выставлении статуса устройства с синонимом: {synonym ?? "Синоним отсутствует"} и ip: {ipAddress}, mac: {macAddress}:\n{e.Message}");
                    return false;
                }

                return true;
            }
        }
    }
}
