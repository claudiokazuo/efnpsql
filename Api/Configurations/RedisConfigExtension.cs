using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Api.Configurations
{
    public static class RedisConfigExtension
    {
        public static void AddRedisConfig(this IServiceCollection services, string configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConfigurationOptions = ConfigurationOptions.Parse(configuration);
            });
        }        
    }
}
