using Languamania.Data.Providers;
using Languamania.Data.Repositories;
using Languamania.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Languamania.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services, string connectionString)
        {
            //request scope
            services.AddScoped<IDbAccessProvider>(x => new MainDbAccessProvider(connectionString));
            services.AddScoped<ITranslationItemsRepository, TranslationItemsRepository>();
        }
    }
}
