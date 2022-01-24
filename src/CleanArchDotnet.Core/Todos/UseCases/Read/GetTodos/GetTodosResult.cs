namespace CleanArchDotnet.Core.Todos.UseCases.Read.GetTodos;

public record GetTodosResult(IReadOnlyList<GetTodosResult.GetTodoResult> Items)
{
    public record GetTodoResult(
        Guid Id,
        string Description,
        TodoStatus Status
    );
}

