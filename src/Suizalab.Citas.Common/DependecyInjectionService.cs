using Microsoft.Extensions.DependencyInjection;

namespace Suizalab.Citas.Common
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
