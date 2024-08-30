namespace Dls.Erp.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins(configuration["Config:OriginCors"]!)
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            return services;
        }
    }
}
