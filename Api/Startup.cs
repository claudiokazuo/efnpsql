using Application.Handlers;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddTransient(typeof(IGenericRepository<Person>),
                typeof(PersonRepository<Person>));
            services.AddTransient(typeof(IGenericRepository<Document>),
                typeof(DocumentRepository<Document>));
            services.AddTransient(typeof(IGenericRepository<DocumentType>),
                typeof(GenericRepository<DocumentType>));

            services.AddTransient<IGenericHandler<Application.Commands.Create.PersonCommand>, PersonHandler>();
            services.AddTransient<IGenericHandler<Application.Commands.Create.DocumentCommand>, DocumentHandler>();
            services.AddTransient<IGenericHandler<Application.Commands.Create.DocumentTypeCommand>, DocumentTypeHandler>();

            services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
        }
    }
}
