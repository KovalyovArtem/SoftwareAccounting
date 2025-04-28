using Dapper;
using Npgsql;

namespace SoftwareAccounting.Domain.Extensions
{
    public static class NpgSqlExtensions
    {
        /// <summary>
        /// Расширения получение транзакции с логовированием
        /// </summary>
        /// <param name="dbConnection">Подключение к БД</param>
        /// <param name="isLog">параметр из настроек</param>
        public static async Task<NpgsqlTransaction> BeginTransactionLogAsync(this NpgsqlConnection dbConnection, bool isLog = false)
        {
            var transaction = await dbConnection.BeginTransactionAsync();

            if (isLog)
            {
                await dbConnection.ExecuteAsync("select cdc.set_sotr('UniverLabService');", transaction);
            }

            return transaction;
        }
    }

}
