using System.Threading.Tasks;
using CleanArchDotnet.Core.Todos.UseCases.Writes.CreateTodo;
using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using CleanArchDotnet.Tests.Integration.Common.Fixtures;
using CleanArchDotnet.Tests.Integration.Common.Tests;
using FluentAssertions;
using Xunit;

namespace CleanArchDotnet.Tests.Integration.Todos.Write;

public class CreateTodoTest: BaseTest
{
    
    public CreateTodoTest(Fixture fixture): 
        base(fixture) {}
    
    [Fact]
    public async Task Should_Add_Fail_Validation_If_Description_Is_Too_Short()
    {
        var description = Faker.Lorem.Letter(2);
        var todo = new CreateTodoCommand(description);
        
        var result = await Mediator.Send(todo);
        
        result.Should().BeNull();
        DomainValidationProvider
            .GetFails()
            .Should()
            .ContainSingle().And
            .Contain(e => e.Type == FailType.FailValidation);
    }
    
    [Fact]
    public async Task Should_Add_Fail_Validation_If_Description_Is_Too_Long()
    {
        var description = Faker.Lorem.Letter(256);
        var todo = new CreateTodoCommand(description);
        
        var result = await Mediator.Send(todo);
        
        result.Should().BeNull();
        DomainValidationProvider
            .GetFails()
            .Should()
            .ContainSingle().And
            .Contain(e => e.Type == FailType.FailValidation);
    }
    
    [Fact]
    public async Task Should_Save()
    {
        var description = Faker.Lorem.Letter(10);
        var todo = new CreateTodoCommand(description);
        
        var result = await Mediator.Send(todo);
        result.Should().NotBeNull();
        DomainValidationProvider.GetFails().Should().BeEmpty();
        (await Todos.GetById(result.Id)).Should().NotBeNull();
    }
}