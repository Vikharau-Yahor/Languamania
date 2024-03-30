using Languamania.Data.Providers;

namespace Languamania.Server.AppStart.Middlewares
{
    public class DataAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public DataAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IDbAccessProvider dbAccessProvider)
        {
            dbAccessProvider.GetOrCreateConnection();
            try
            {
                dbAccessProvider.StartTransaction();
                await _next(context);
                await dbAccessProvider.CommitAsync();
            }
            catch (Exception)
            {
                await dbAccessProvider.RollbackAsync();
                throw;
            }
            finally
            {
                dbAccessProvider.CloseConnection();
            }

        }
    }
}
