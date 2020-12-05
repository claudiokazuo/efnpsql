using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repositories;

namespace Api.Configurations
{
    public static class RepositoryConfigExtension
    {
        public static void AddRepositoryConfig(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IGenericRepository<Person>), typeof(PersonRepository<Person>));
            services.AddTransient(typeof(IGenericRepository<Document>), typeof(DocumentRepository<Document>));
        }
    }
}
