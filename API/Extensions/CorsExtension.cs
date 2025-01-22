namespace API.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ReactApp", policyBuilder =>
                {

                    policyBuilder.WithOrigins("http://localhost:3000")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();
                });
            });

            return services;
        }
    }
}