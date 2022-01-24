using CleanArchDotnet.SharedKernel.DataContracts;
using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Writes.DeleteTodo;

public record DeleteTodoCommand(Guid Id): IRequest<EmptyResult>;