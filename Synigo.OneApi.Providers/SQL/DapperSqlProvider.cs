using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Model;

namespace Synigo.OneApi.Providers.SQL
{
    public class DapperSqlProvider<T1> : ISqlProvider<T1> where T1 : AbstractEntity
    { 
        private readonly string _sqlConnectionString;

        public DapperSqlProvider(string sqlConnectionString)
        {
            if (string.IsNullOrEmpty(sqlConnectionString))
            {
                throw new ArgumentException(null, nameof(sqlConnectionString));
            }

            _sqlConnectionString = sqlConnectionString;
        }

        public async Task DeleteAsync(string sql, object param)
        {
            using var sqlConnection = new SqlConnection(_sqlConnectionString);

            await sqlConnection.ExecuteAsync(sql, param);
        }

        public async Task<T1> GetAsync(string sql, object param)
        {
            using var sqlConnection = new SqlConnection(_sqlConnectionString);

            return await sqlConnection.QueryFirstOrDefaultAsync<T1>(sql, param);      
        }

        public async Task<IEnumerable<T1>> GetListAsync(string sql, object param)
        {
            using var sqlConnection = new SqlConnection(_sqlConnectionString);

            return await sqlConnection.QueryAsync<T1>(sql, param);
        }

        public async Task<List<T1>> StoreAsync(string sql, List<T1> items)
        {
            using var sqlConnection = new SqlConnection(_sqlConnectionString);
            await sqlConnection.ExecuteAsync(sql, items);

            return items;
        }

        public async Task<T1> StoreAsync(string sql, T1 item)
        {
            using var sqlConnection = new SqlConnection(_sqlConnectionString);
            await sqlConnection.ExecuteAsync(sql, item);

            return item;
        }
    }
}