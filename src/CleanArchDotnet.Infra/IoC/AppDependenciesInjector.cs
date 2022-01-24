using CleanArchDotnet.Infra.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Infra.IoC;

public static class AppDependenciesInjector
{
    public static void InjectAppDependencies(
        this IServiceCollection services,
        AppSettings appSettings
    ) => services
        .InjectHandlersAndBehaviours()
        .InjectValidators()
        .InjectProviders()
        .InjectRepositories()
        .InjectSettings(appSettings)
        .InjectDatabase(appSettings);
}