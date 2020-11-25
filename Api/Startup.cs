using Application.Handlers;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        private readonly string _policyName = "PolicyAllowAll";
        private readonly string _healthPath = "/health";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
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

            services.AddHealthChecks();

            services.AddSwaggerGen();

            services.AddDbContext<GenericContext>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IGenericRepository<Person>), typeof(PersonRepository<Person>));
            services.AddTransient(typeof(IGenericRepository<Document>), typeof(DocumentRepository<Document>));
            

            services.AddTransient<IGenericHandler<Application.Commands.Create.PersonCommand>, PersonHandler>();
            services.AddTransient<IGenericHandler<Application.Commands.Create.DocumentCommand>, DocumentHandler>();
            services.AddTransient<IGenericHandler<Application.Commands.Create.DocumentTypeCommand>, DocumentTypeHandler>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_policyName);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks(_healthPath);
        }
    }
}
