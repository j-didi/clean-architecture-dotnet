using CleanArchDotnet.Core.Todos.UseCases.Read.GetTodoById;
using CleanArchDotnet.SharedKernel.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchDotnet.Infra.IoC;

internal static class MediatrInjector
{
    internal static IServiceCollection InjectHandlersAndBehaviours(
        this IServiceCollection services
    ) => services.AddMediatR(typeof(GetTodoByIdHandler))
        .AddTransient(typeof(ILogger<>), typeof(Logger<>))
        .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
        .AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastBehavior<,>));
}