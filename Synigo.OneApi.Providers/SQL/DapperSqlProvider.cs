using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Model;

namespace Synigo.OneApi.Providers.SQL
{
    public class DapperSqlProvider<T1> : ISqlProvider<T1> where T1 : AbstractEntity
    { 
        private readonly string _connectionString;

        public DapperSqlProvider(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task DeleteAsync(string sql)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.ExecuteAsync(sql, new { });
        }

        public Task<T1> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<System.Collections.Generic.List<T1>> StorAsync(System.Collections.Generic.List<T1> items)
        {
            throw new NotImplementedException();
        }

        public Task<T1> StoreAsync(T1 item)
        {
            throw new NotImplementedException();
        }
    }
}
