using Dls.Erp.Services.WebApi.Modules.Feature;
using Dls.Erp.Services.WebApi.Modules.Injection;
using Dls.Erp.Services.WebApi.Modules.Mapper;
using Dls.Erp.Services.WebApi.Modules.Swagger;
using Dls.Erp.Services.WebApi.Modules.Validator;
using Dls.Erp.Services.WebApi.Modules.Authentication;
using Dls.Erp.Services.WebApi.Modules.Versioning;
using Dls.Erp.Services.WebApi.Modules.HealthCheck;
using Dls.Erp.Services.WebApi.Modules.Watch;
using Dls.Erp.Services.WebApi.Modules.Redis;
using Dls.Erp.Services.WebApi.Modules.RateLimiter;

namespace Dls.Erp.Services.WebApi
{
    public static class Startup
    {

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddMapper();
            services.AddFeature(configuration);
            services.AddInjection();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddAuthentication(configuration);
            services.AddVersioning();
            services.AddSwagger();
            services.AddValidator();
            services.AddHealthCheck(configuration);
            services.AddWatchDog(configuration);
            services.AddRedisCache(configuration);
            services.AddRateLimiting(configuration);
        }        
    }
}
