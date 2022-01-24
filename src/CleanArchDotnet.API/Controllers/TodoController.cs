using CleanArchDotnet.API.Common;
using CleanArchDotnet.Core.Todos.UseCases.Read.GetTodoById;
using CleanArchDotnet.Core.Todos.UseCases.Read.GetTodos;
using CleanArchDotnet.Core.Todos.UseCases.Writes.CreateTodo;
using CleanArchDotnet.Core.Todos.UseCases.Writes.DeleteTodo;
using CleanArchDotnet.Core.Todos.UseCases.Writes.MarkTodoAsDone;
using CleanArchDotnet.SharedKernel.DataContracts;
using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDotnet.API.Controllers;

public class TodoController: EndpointController
{
    private readonly IMediator _mediator;

    public TodoController(
        IMediator mediator,
        IDomainValidationProvider domainValidation
    ): base(domainValidation)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new EmptyQuery<GetTodosResult>();
        var result = await _mediator.Send(query);
        return Result(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetTodoByIdQuery(id);
        var result = await _mediator.Send(query);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoCommand command)
    {
        var result = await _mediator.Send(command);
        return Result(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteTodoCommand(id);
        await _mediator.Send(command);
        return Result();
    }
    
    [HttpPut("{id:guid}/MarkTodoAsDone")]
    public async Task<IActionResult> MarkAsDone([FromRoute] Guid id)
    {
        var command = new MarkTodoAsDoneCommand(id);
        await _mediator.Send(command);
        return Result();
    }
}