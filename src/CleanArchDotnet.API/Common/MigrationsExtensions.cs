using CleanArchDotnet.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDotnet.API.Common;

public static class MigrationsExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = GetDatabaseContext(scope);
        if (ContextHasPendingMigrations(context))
            context.Database.Migrate();
    }

    private static bool ContextHasPendingMigrations(DbContext context) =>
        context.Database.GetPendingMigrations().Any();

    private static DatabaseContext GetDatabaseContext(IServiceScope scope) =>
        scope.ServiceProvider.GetRequiredService<DatabaseContext>();
}