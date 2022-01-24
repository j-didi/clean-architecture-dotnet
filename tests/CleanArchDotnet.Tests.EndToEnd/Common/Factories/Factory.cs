using CleanArchDotnet.API;
using CleanArchDotnet.API.Common;
using CleanArchDotnet.Infra.Database.Context;
using CleanArchDotnet.Infra.IoC;
using CleanArchDotnet.Infra.Settings;
using CleanArchDotnet.Tests.EndToEnd.Common.Ioc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Tests.EndToEnd.Common.Factories;
public class Factory: WebApplicationFactory<Program>
{
    private ServiceProvider ServiceProvider { get; set; }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(e =>
        {
            e.InjectInMemoryDatabase()
                .InjectMocks();

            ServiceProvider = e.BuildServiceProvider();
            CreateDatabase();
        });
    }
    
    private void CreateDatabase()
    {
        var databaseContext = Get<DatabaseContext>();
        databaseContext.Database.EnsureCreated();
    }
    
    private static AppSettings CreateAppSettings() =>
        new()
        {
            ConnectionString = "InMemory",
            IsTestEnvironment = true
        };
    
    private T Get<T>() where T : notnull => 
        ServiceProvider.GetRequiredService<T>();
}