using Microsoft.Data.SqlClient;
using System.Data;

namespace Languamania.Data.Providers
{
    public interface IDbAccessProvider
    {
        SqlConnection GetOrCreateConnection();
        void CloseConnection();

        SqlTransaction StartTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task CommitAsync();
        Task RollbackAsync();

        Task<IEnumerable<T>> QueryListAsync<T>(string sql) where T : class;
        Task InsertAsync(string sql, object param);
        Task UpdateAsync(string sql, object param);
    }
}
