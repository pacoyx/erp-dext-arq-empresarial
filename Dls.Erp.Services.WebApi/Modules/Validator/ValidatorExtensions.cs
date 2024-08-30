using Dls.Erp.Application.Validator;

namespace Dls.Erp.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDtoValidator>();
            return services;
        }
    }
}
