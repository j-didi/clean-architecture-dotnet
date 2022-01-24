namespace CleanArchDotnet.Core.Todos.UseCases.Read.GetTodoById;

public record GetTodoByIdResult(
    Guid Id,
    string Description,
    TodoStatus Status
);