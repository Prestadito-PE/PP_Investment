using Microsoft.Extensions.DependencyInjection;
using Prestadito.Investment.Infrastructure.Proxies.Settings.Interfaces;
using Prestadito.Investment.Infrastructure.Proxies.Settings.Proxies;

namespace Prestadito.Investment.Infrastructure.Proxies.Settings.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProxies(this IServiceCollection services)
        {
            services.AddHttpClient<ISettingProxy, SettingProxy>();

            return services;
        }
    }
}
