using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Tests.Unit.Common;

public class Fixture
{
    private ServiceProvider ServiceProvider { get; }

    public Fixture()
    {
        var services = new ServiceCollection();
        services.AddTransient<IDomainValidationProvider, DomainValidationProvider>();
        ServiceProvider = services.BuildServiceProvider();
    }
    
    public T Get<T>() where T : notnull => 
        ServiceProvider.GetRequiredService<T>();
}