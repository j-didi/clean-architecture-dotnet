using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.SharedKernel.DataContracts;
using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Writes.MarkTodoAsDone;

public class MarkTodoAsDoneHandler : IRequestHandler<MarkTodoAsDoneCommand, EmptyResult>
{
    private readonly IDomainValidationProvider _domainValidation;
    private readonly ITodos _todos;

    public MarkTodoAsDoneHandler(
        IDomainValidationProvider domainValidation,
        ITodos todos
    )
    {
        _domainValidation = domainValidation;
        _todos = todos;
    }

    public async Task<EmptyResult> Handle(
        MarkTodoAsDoneCommand command, 
        CancellationToken cancellationToken
    )
    {
        var todo = await _todos.GetById(command.Id);

        if (todo == null)
        {
            _domainValidation.AddNotFound();
            return EmptyResult.Create();
        }
        
        todo.MarkTodoAsDone();
        await _todos.Update(todo);
        return EmptyResult.Create();
    }
}