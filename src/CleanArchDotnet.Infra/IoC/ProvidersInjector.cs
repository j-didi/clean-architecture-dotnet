using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Infra.IoC;

internal static class ProvidersInjector
{
    internal static IServiceCollection InjectProviders(
        this IServiceCollection services
    ) => services.AddScoped<IDomainValidationProvider, DomainValidationProvider>();
}