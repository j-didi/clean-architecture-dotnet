using CleanArchDotnet.SharedKernel.DataContracts;
using MediatR;

namespace CleanArchDotnet.Core.Todos.UseCases.Writes.MarkTodoAsDone;

public record MarkTodoAsDoneCommand(Guid Id): IRequest<EmptyResult>;