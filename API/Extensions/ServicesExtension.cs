using Infrastructure.Services.Auth0;

namespace API.Extensions
{
    public static  class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuth0Service, Auth0Service>();

            return services;
        }
    }
}
