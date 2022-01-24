using Bogus;
using CleanArchDotnet.Infra.Database.Context;
using CleanArchDotnet.Infra.IoC;
using CleanArchDotnet.Infra.Settings;
using CleanArchDotnet.Tests.Integration.Common.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Tests.Integration.Common.Fixtures;

public class Fixture
{
    private ServiceProvider ServiceProvider { get; }

    public Fixture()
    {
        var services = new ServiceCollection();
        services
            .InjectInMemoryDatabase()
            .InjectMocks()
            .InjectAppDependencies(CreateAppSettings());

        ServiceProvider = services.BuildServiceProvider();
        CreateDatabase();
    }
    
    private static AppSettings CreateAppSettings() =>
        new()
        {
            ConnectionString = "InMemory",
            IsTestEnvironment = true
        };

    private void CreateDatabase()
    {
        var databaseContext = Get<DatabaseContext>();
        databaseContext.Database.EnsureCreated();
    }
    
    public T Get<T>() where T : notnull => 
        ServiceProvider.GetRequiredService<T>();
}