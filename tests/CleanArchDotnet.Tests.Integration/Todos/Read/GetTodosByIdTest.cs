using System;
using System.Threading.Tasks;
using CleanArchDotnet.Core.Todos.UseCases.Read.GetTodoById;
using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using CleanArchDotnet.Tests.Integration.Common.Fixtures;
using CleanArchDotnet.Tests.Integration.Common.Tests;
using FluentAssertions;
using Xunit;

namespace CleanArchDotnet.Tests.Integration.Todos.Read;

public class GetTodoByIdTest: BaseTest
{

    public GetTodoByIdTest(Fixture fixture): 
        base(fixture) {}
    
    [Fact]
    public async Task Should_Return_Null_Add_A_Not_Found_Fail()
    {
        var query = new GetTodoByIdQuery(Guid.NewGuid()); 
        
        var result = await Mediator.Send(query);
        
        result.Should().BeNull();
        DomainValidationProvider
            .GetFails()
            .Should()
            .ContainSingle().And
            .Contain(e => e.Type == FailType.NotFound);
    }
    
    [Fact]
    public async Task Should_Return_And_Not_Add_Fail()
    {
        await Todos.Create(Todo);
        var query = new GetTodoByIdQuery(Todo.Id); 
        
        var result = Mediator.Send(query);
        
        result.Should().NotBeNull();
        DomainValidationProvider
            .GetFails()
            .Should()
            .BeEmpty();
    }
}