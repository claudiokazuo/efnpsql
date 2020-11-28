using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static class CorsConfigExtension
    {
        private static readonly string _policyName = "PolicyAllowAll";
        
        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(
                policy => policy.AddPolicy(_policyName,
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                }));
        }

        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors(_policyName);
        }
    }
}
