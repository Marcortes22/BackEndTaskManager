namespace API.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ReactApp", policyBuilder =>
                {
                    

                    policyBuilder.WithOrigins(_configuration["FrontEndUrl"], _configuration["FrontEndTunnelUrl"])
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();
                });
            });

            return services;
        }
    }
}