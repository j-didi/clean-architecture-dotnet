using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Writes.CreateTodo;

public record CreateTodoCommand(string Description): 
    IRequest<CreateTodoResult>;