using System.Collections.Immutable;
using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.SharedKernel.DataContracts;
using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Read.GetTodos;

public class GetTodosHandler : 
    IRequestHandler<EmptyQuery<GetTodosResult>, GetTodosResult>
{
    private readonly ITodos _todos;

    public GetTodosHandler(ITodos todos)
    {
        _todos = todos;
    }
    public async Task<GetTodosResult> Handle(
        EmptyQuery<GetTodosResult> request, 
        CancellationToken cancellationToken
    )
    {
        var todos = await _todos.Get();
        var items = todos
            .Select(e => new GetTodosResult.GetTodoResult(e.Id, e.Description, e.Status))
            .ToImmutableList();

        return new GetTodosResult(items);
    }
}