using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}


