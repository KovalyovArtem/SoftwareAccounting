using Npgsql;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using SoftwareAccounting.Common.Models.RegisterModels;
using Dapper;
using SoftwareAccounting.Domain.Extensions;
using System.Numerics;

namespace SoftwareAccounting.Domain.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly NpgsqlDataSource _dataSource;
        private readonly ILogger<AccountRepository> _logger;
        private readonly IOptions<AppSettings> _settings;

        public AccountRepository(NpgsqlDataSource dataSource,
                                 IOptions<AppSettings> settings,
                                 ILogger<AccountRepository> logger)
        {
            _dataSource = dataSource;
            _settings = settings;
            _logger = logger;
        }

        public async Task<AccountModel> GetAccountByUserName(string userName)
        {
            #region SQL

            var sql = @"

SELECT s.id AS Id,
       s.login AS UserName,
       s.hash_password AS HashPassword
FROM mir.sysuser s
WHERE s.login = @login::varchar
LIMIT 1

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var param = new { login = userName };
                var res = await dbConnection.QueryFirstOrDefaultAsync<AccountModel>(sql, param);
                return res;
            }
        }

        public async Task<bool> IsUserNameExist(string userName)
        {
            #region SQL

            var sql = @"

SELECT s.login AS UserName,
       s.hash_password AS HashPassword
FROM mir.sysuser s
WHERE s.login = @login
LIMIT 1

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var param = new { login = userName };
                var res = await dbConnection.QueryFirstOrDefaultAsync<bool>(sql, param);
                return res;
            }
        }

        public async Task<bool> RegisterUser(AccountModel model)
        {
            #region SQL

            var sql = @"

INSERT INTO mir.sysuser(login, hash_password)
    VALUES (@login, @password)

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var transaction = await dbConnection.BeginTransactionLogAsync(_settings.Value.IsLog);

                try
                {
                    var param = new
                    {
                        login = model.UserName,
                        password = model.HashPassword,
                    };
                    await dbConnection.ExecuteAsync(sql, param, transaction);

                    transaction.Commit();

                    _logger.LogInformation($"Пользователь {model.UserName} успешно добавлен!");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    _logger.LogInformation(e, $"Ошибка при добавлении пользователя {model.UserName}:\n{e.Message}");
                    return false;
                }

                return true;
            }
        }
    }
}
