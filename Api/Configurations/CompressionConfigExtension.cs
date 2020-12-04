using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace Api.Configurations
{
    public static class CompressionConfigExtension
    {
        public static void AddCompressionConfig(this IServiceCollection services)
        {
            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
        }

        public static void UseCompressionConfig(this IApplicationBuilder app)
        {
            app.UseResponseCompression();
        }
    }
}
