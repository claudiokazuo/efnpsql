using Api.DataTransferObjects.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static class AutoMapperConfigExtension
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);           
        }        
    }
}
