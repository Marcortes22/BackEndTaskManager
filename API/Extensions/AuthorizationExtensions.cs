using API.Authorization.Handlers;
using API.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace API.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuth0Authorization(this IServiceCollection services, IConfiguration configuration)
        {
            var auth0Domain = configuration["Auth0Domain"];

            var domain = $"https://{auth0Domain}/";
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages", policy => policy.Requirements.Add(new
                HasScopeRequirement("read:messages", domain)));
                
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            return services;
        }
    }
}
