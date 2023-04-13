using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Prestadito.Investment.Infrastructure.Data.Context;
using Prestadito.Investment.Infrastructure.Data.Interface;
using Prestadito.Investment.Infrastructure.Data.Repositories;
using Prestadito.Investment.Infrastructure.Data.Settings;

namespace Prestadito.Investment.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        private static IServiceCollection AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<InvestmentDBSettings>(configuration.GetSection(nameof(InvestmentDBSettings)));
            services.AddSingleton<IInvestmentDBSettings>(sp => sp.GetRequiredService<IOptions<InvestmentDBSettings>>().Value);
            services.AddScoped<IMongoContext, MongoContext>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFinancingRepository, FinancingRepository>();

            return services;
        }

        public static IServiceCollection AddDBServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDbContext(configuration);
            services.AddRepositories();

            return services;
        }
    }
}
