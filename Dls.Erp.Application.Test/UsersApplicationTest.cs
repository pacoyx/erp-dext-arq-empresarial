using Dls.Erp.Application.Interface;
using Dls.Erp.Services.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Dls.Erp.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;


        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            //var builder = new WebApplicationFactory<MiProyecto.Startup>();
            //var app = builder.Build();

            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            var confbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = confbuilder.Build();
            var services = new ServiceCollection();
            Startup.ConfigureServices(services, _configuration);
            //Startup.Configure(app, app.Environment);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornaMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange
            var username = string.Empty;
            var password = string.Empty;
            var expected = "Errores de Validación";

            //Act
            var result = context.Authenticate(username, password);
            var actual = result.Message;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametros_RetornaMensajeExito()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange
            var username = "cbazan";
            var password = "123456";
            var expected = "Autenticacion exitosa!!";

            //Act
            var result = context.Authenticate(username, password);
            var actual = result.Message;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornaMensajeNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange
            var username = "cbazan";
            var password = "1234567";
            var expected = "Usuario no existe";

            //Act
            var result = context.Authenticate(username, password);
            var actual = result.Message;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}