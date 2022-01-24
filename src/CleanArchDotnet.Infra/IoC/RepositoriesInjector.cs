using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.Infra.Database.Todos;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Infra.IoC;

internal static class RepositoriesInjector
{
    internal static IServiceCollection InjectRepositories(
        this IServiceCollection services
    ) => services.AddTransient<ITodos, TodoRepository>();
}