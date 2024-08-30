using Dls.Erp.Transversal.Mapper;

namespace Dls.Erp.Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            return services;
        }
    }
}
