using CleanArchDotnet.Infra.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Infra.IoC;

internal static class SettingsInjector
{
    internal static IServiceCollection InjectSettings(
        this IServiceCollection services,
        AppSettings appSettings
    ) => services.AddSingleton(appSettings);
}