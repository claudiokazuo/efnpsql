using Api.Configurations;
using Api.Filters;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        private static readonly string _healthPath = "/health";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(ErrorResponseFilter)));
            services.AddHealthChecks();
            services.AddCompressionConfig();
            services.AddSwaggerConfig();
            services.AddCorsConfig();
            services.AddDbContext<GenericContext>();
            services.AddRepositoryConfig();
            services.AddHandlerConfig();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks(_healthPath);
            app.UseCompressionConfig();
            app.UseSwaggerConfig();
            app.UseCorsConfig();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddlewareConfig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
