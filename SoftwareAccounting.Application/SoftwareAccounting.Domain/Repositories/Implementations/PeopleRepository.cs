using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.PoepleModels;
using SoftwareAccounting.Domain.Models;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Domain.Repositories.Implementations
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly NpgsqlDataSource _dataSource;
        private readonly ILogger<PeopleRepository> _logger;
        private readonly IOptions<AppSettings> _settings;

        public PeopleRepository(
            NpgsqlDataSource dataSource,
            ILogger<PeopleRepository> logger,
            IOptions<AppSettings> settings)
        {
            _dataSource = dataSource;
            _logger = logger;
            _settings = settings;
        }

        public async Task<List<Employer>> GetEmployers()
        {
            #region SQL

            var sql = @"

SELECT s.id AS Id,
	   s.surname AS Surname,
	   s.name AS Name,
	   s.patronymic AS Patronymic,
	   s.email AS Email,
	   s.telephone AS Telephone,
	   to_char(s.birthdate, 'dd.mm.yyyy') AS Birthdate
FROM mir.sotr s

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var res = await dbConnection.QueryAsync<Employer>(sql);
                return res.ToList();
            }
        }

        public async Task<List<User>> GetUsers()
        {
            #region SQL

            var sql = @"

SELECT sys.id AS Id,
	   sys.login AS Login,
	   s.email
FROM mir.sysuser sys
LEFT JOIN mir.sotr s ON s.sysuser_id = sys.id

";

            #endregion

            using (NpgsqlConnection dbConnection = await _dataSource.OpenConnectionAsync())
            {
                var res = await dbConnection.QueryAsync<User>(sql);
                return res.ToList();
            }
        }
    }
}
