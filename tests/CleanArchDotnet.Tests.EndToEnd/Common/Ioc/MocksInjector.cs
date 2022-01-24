using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Tests.EndToEnd.Common.Ioc;

internal static class MocksInjector
{
    internal static IServiceCollection InjectMocks(
        this IServiceCollection services
    ) => services;
}