using CleanArchDotnet.Core.Ports;
using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Writes.CreateTodo;

public class CreateTodoHandler : 
    IRequestHandler<CreateTodoCommand, CreateTodoResult>
{
    private readonly ITodos _todos;

    public CreateTodoHandler(ITodos todos)
    {
        _todos = todos;
    }

    public async Task<CreateTodoResult> Handle(
        CreateTodoCommand command, 
        CancellationToken cancellationToken
    )
    {
        var todo = new Todo(command.Description);
        await _todos.Create(todo);

        return new CreateTodoResult(todo.Id);
    }
}