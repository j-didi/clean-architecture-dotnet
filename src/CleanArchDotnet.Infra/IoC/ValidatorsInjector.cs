using CleanArchDotnet.Core.Todos.UseCases.Writes.CreateTodo;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDotnet.Infra.IoC;

internal static class ValidatorsInjector
{
    internal static IServiceCollection InjectValidators(
        this IServiceCollection services
    ) => services.AddValidatorsFromAssembly(typeof(CreateTodoValidator).Assembly);
}