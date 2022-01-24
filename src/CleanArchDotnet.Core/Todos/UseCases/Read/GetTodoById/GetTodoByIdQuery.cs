using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Read.GetTodoById;

public record GetTodoByIdQuery(Guid Id): 
    IRequest<GetTodoByIdResult?>; 