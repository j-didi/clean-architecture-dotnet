using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Read.GetTodoById;

public class GetTodoByIdHandler : 
    IRequestHandler<GetTodoByIdQuery, GetTodoByIdResult?>
{
    private readonly IDomainValidationProvider _domainValidation;
    private readonly ITodos _todos;

    public GetTodoByIdHandler(
        IDomainValidationProvider domainValidation,
        ITodos todos
    )
    {
        _domainValidation = domainValidation;
        _todos = todos;
    }

    public async Task<GetTodoByIdResult?> Handle(
        GetTodoByIdQuery query, 
        CancellationToken cancellationToken
    )
    {
        var todo = await _todos.GetById(query.Id);

        if (todo == null)
        {
            _domainValidation.AddNotFound();
            return null;
        }

        return new GetTodoByIdResult(todo.Id, todo.Description, todo.Status);
    }
}