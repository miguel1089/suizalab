using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suizalab.Citas.Application.DataBase;
using Suizalab.Citas.Persistence.Database;


namespace Suizalab.Citas.Persistence
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(configuration["SQLConnectionStrings"]));

            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}
