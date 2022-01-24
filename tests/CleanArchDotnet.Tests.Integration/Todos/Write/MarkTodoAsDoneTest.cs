using System;
using System.Threading.Tasks;
using Bogus;
using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.Core.Todos;
using CleanArchDotnet.Core.Todos.UseCases.Writes.DeleteTodo;
using CleanArchDotnet.Core.Todos.UseCases.Writes.MarkTodoAsDone;
using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using CleanArchDotnet.Tests.Integration.Common.Fixtures;
using CleanArchDotnet.Tests.Integration.Common.Tests;
using FluentAssertions;
using Xunit;

namespace CleanArchDotnet.Tests.Integration.Todos.Write;

public class MarkTodoAsDoneTest: BaseTest
{
    public MarkTodoAsDoneTest(Fixture fixture): 
        base(fixture) {}
    
    [Fact]
    public async Task Should_Add_Not_Found_Fail_If_Do_Not_Exists()
    {
        var command = new MarkTodoAsDoneCommand(Guid.NewGuid());
        
        await Mediator.Send(command);
        
        DomainValidationProvider
            .GetFails()
            .Should()
            .ContainSingle().And
            .Contain(e => e.Type == FailType.NotFound);
    }
    
    [Fact]
    public async Task Should_Mark_As_Done()
    {
        var todo = new Todo(Faker.Lorem.Sentence());
        await Todos.Create(todo);
        var command = new MarkTodoAsDoneCommand(todo.Id);
        
        await Mediator.Send(command);
        
        DomainValidationProvider
            .GetFails()
            .Should()
            .BeEmpty();

        var entity = await Todos.GetById(todo.Id);
        entity.Should().NotBeNull();
        entity!.Status.Should().Be(TodoStatus.Done);
    }
}