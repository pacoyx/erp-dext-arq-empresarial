using Dls.Erp.Application.Interface;
using Dls.Erp.Application.Main;
using Dls.Erp.Domain.Core;
using Dls.Erp.Domain.Interface;
using Dls.Erp.Infraestructura.Data;
using Dls.Erp.Infraestructura.Interface;
using Dls.Erp.Infraestructura.Repository;
using Dls.Erp.Transversal.Common;
using Dls.Erp.Transversal.Logging;

namespace Dls.Erp.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<ICategoriesDomain, CategoriesDomain>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            return services;
        }
    }
}
