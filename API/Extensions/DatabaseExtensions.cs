using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MySqlContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b =>
                    b.MigrationsAssembly("Infrastructure"))
                       .EnableSensitiveDataLogging() // Solo para desarrollo
                       .EnableDetailedErrors()
            );

            return services;
        }
    }
}