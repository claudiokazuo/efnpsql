using Application.Commands.DocumentType;
using Application.Commands.Documment;
using Application.Commands.Person;
using Application.Handlers;
using Domain.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static class HandlerConfigExtension
    {
        public static void AddHandlerConfig(this IServiceCollection services)
        {
            services.AddTransient<IGenericHandler<PersonCreateCommand>, PersonHandler>();
            services.AddTransient<IGenericHandler<PersonUpdateCommand>, PersonHandler>();
            services.AddTransient<IGenericHandler<DocumentCreateCommand>, DocumentHandler>();
            services.AddTransient<IGenericHandler<DocumentTypeCreateCommand>, DocumentTypeHandler>();

        }
    }
}
