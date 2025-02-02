using Application.Commons.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json;

namespace API.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuth0Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            var auth0Domain = configuration["Auth0Domain"];
            var auth0Audience = configuration["Auth0Audience"];

            var domain = $"https://{auth0Domain}/";
          

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = auth0Audience;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier,
                       
                        
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                         {
                             context.HandleResponse();

                            
                             context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                             context.Response.ContentType = "application/json";

                             BaseResponse<string> UnauthorizedResponse = new BaseResponse<string>("", false, "Your session has expired");
                            
                             var UnauthorizeJsondResponse = JsonSerializer.Serialize(UnauthorizedResponse);

                             Console.WriteLine(UnauthorizeJsondResponse);

                              await context.HttpContext.Response.WriteAsync(UnauthorizeJsondResponse);
                             

                         }
                    };

                });
           

            return services;
        }
    }
}