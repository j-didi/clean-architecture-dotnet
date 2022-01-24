using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Tests.Integration.Common.IoC;

internal static class MocksInjector
{
    internal static IServiceCollection InjectMocks(
        this IServiceCollection services
    ) => services;
}