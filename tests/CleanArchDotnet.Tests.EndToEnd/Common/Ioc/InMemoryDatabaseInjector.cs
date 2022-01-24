using System;
using CleanArchDotnet.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Tests.EndToEnd.Common.Ioc;

internal static class InMemoryDatabaseInjector
{
    internal static IServiceCollection InjectInMemoryDatabase(
        this IServiceCollection services
    ) => services
            .AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<DatabaseContext>(e => e.UseInMemoryDatabase(Guid.NewGuid().ToString()));
}