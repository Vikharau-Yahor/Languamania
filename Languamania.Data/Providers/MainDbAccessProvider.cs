using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languamania.Data.Providers
{
    public class MainDbAccessProvider(string connectionString) : IDbAccessProvider, IDisposable
    {
        private SqlConnection? connection;
        private SqlTransaction? currentTransaction;

        #region DB connection management
        public SqlConnection GetOrCreateConnection()
        {
            connection = connection ?? new SqlConnection(connectionString);
            return connection;
        }
        public void CloseConnection()
        {
            currentTransaction?.Dispose();
            currentTransaction = null;

            connection?.Close();
            connection?.Dispose();
            connection = null;
        }
        #endregion

        #region Transactions management
        public SqlTransaction StartTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            connection = GetOrCreateConnection();
            connection.Open();

            if (currentTransaction != null) {
                throw new InvalidOperationException("Attempt to start transaction while old one still alive");
            }
            currentTransaction = connection.BeginTransaction(isolationLevel);
            return currentTransaction;
        }

        public async Task CommitAsync()
        {
            await currentTransaction?.CommitAsync();
            currentTransaction?.Dispose();
            currentTransaction = null;
        }

        public async Task RollbackAsync()
        {
            await currentTransaction?.RollbackAsync();
            currentTransaction?.Dispose();
            currentTransaction = null;
        }
        #endregion

        #region Query execution
        public async Task<IEnumerable<T>> QueryListAsync<T>(string sql, object? param = null) where T: class
        {
            return await connection.QueryAsync<T>(sql, param: param, transaction: currentTransaction);
        }
        public async Task InsertAsync(string sql, object param)
        {
            await connection.ExecuteAsync(sql, param, transaction: currentTransaction);
        }

        public async Task UpdateAsync(string sql, object param)
        {
            await connection.ExecuteAsync(sql, param, transaction: currentTransaction);
        }
        #endregion
        public void Dispose()
        {
            CloseConnection();
        }
    }
}
