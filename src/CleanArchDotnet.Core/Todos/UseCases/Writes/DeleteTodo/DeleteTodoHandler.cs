using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.SharedKernel.DataContracts;
using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Writes.DeleteTodo;

public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, EmptyResult>
{
    private readonly IDomainValidationProvider _domainValidation;
    private readonly ITodos _todos;

    public DeleteTodoHandler(
        IDomainValidationProvider domainValidation,
        ITodos todos
    )
    {
        _domainValidation = domainValidation;
        _todos = todos;
    }

    public async Task<EmptyResult> Handle(
        DeleteTodoCommand command, 
        CancellationToken cancellationToken
    )
    {
        var todo = await _todos.GetById(command.Id);

        if (todo == null)
        {
            _domainValidation.AddNotFound();
            return EmptyResult.Create();
        }
        
        todo.MarkTodoAsRemoved();
        await _todos.Update(todo);
        return EmptyResult.Create();
    }
}