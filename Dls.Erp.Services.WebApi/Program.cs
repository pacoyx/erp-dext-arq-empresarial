using Dls.Erp.Services.WebApi;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);
Startup.ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();

//Startup.Configure(app, app.Environment);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();    
    app.UseSwaggerUI(
        options =>
        {
            var descriptions = app.DescribeApiVersions();

            //var descriptions = provider.ApiVersionDescriptions;
            foreach (var description in descriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });
//}

app.UseWatchDogExceptionLogger();
app.UseCors(MyAllowSpecificOrigins);
//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseEndpoints(_ => { });
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapControllers();
app.UseWatchDog(conf => {
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});
app.Run();

