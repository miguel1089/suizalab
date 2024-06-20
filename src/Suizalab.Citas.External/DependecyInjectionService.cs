using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Suizalab.Citas.External
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }
    }
}
