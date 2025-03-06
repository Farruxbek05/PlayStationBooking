using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            return services;
        }


        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PlayStationDbContext>(options =>
                options.UseNpgsql(connectionString,
                    opt => opt.MigrationsAssembly(typeof(PlayStationDbContext).Assembly.FullName)));
        }
    }
}
