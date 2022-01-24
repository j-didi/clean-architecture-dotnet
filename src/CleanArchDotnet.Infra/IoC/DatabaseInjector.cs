using CleanArchDotnet.Infra.Database.Context;
using CleanArchDotnet.Infra.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchDotnet.Infra.IoC;

internal static class DatabaseInjector
{
    internal static IServiceCollection InjectDatabase(
        this IServiceCollection services,
        AppSettings appSettings
    )
    {
        if (appSettings.IsTestEnvironment)
            return services;
        
        return services.AddDbContext<DatabaseContext>(e =>
            e.UseNpgsql(appSettings.ConnectionString)
                .ConfigureWarnings(x => x.Ignore(CoreEventId.SensitiveDataLoggingEnabledWarning))
                .LogTo(
                    Console.WriteLine,
                    new[]
                    {
                        DbLoggerCategory.Database.Command.Name
                    },
                    LogLevel.Information,
                    DbContextLoggerOptions.DefaultWithLocalTime |
                    DbContextLoggerOptions.SingleLine)
                .EnableSensitiveDataLogging()
        );
    }
}