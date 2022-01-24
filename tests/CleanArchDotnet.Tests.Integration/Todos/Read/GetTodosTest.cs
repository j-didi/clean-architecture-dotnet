using System.Threading.Tasks;
using CleanArchDotnet.Core.Todos;
using CleanArchDotnet.Core.Todos.UseCases.Read.GetTodos;
using CleanArchDotnet.Infra.Database.Context;
using CleanArchDotnet.SharedKernel.DataContracts;
using CleanArchDotnet.Tests.Integration.Common.Fixtures;
using CleanArchDotnet.Tests.Integration.Common.Tests;
using FluentAssertions;
using Xunit;

namespace CleanArchDotnet.Tests.Integration.Todos.Read;

public class GetTodosTest: BaseTest
{

    public GetTodosTest(Fixture fixture): 
        base(fixture) {}
    
    [Fact]
    public async Task Should_Return_An_Empty_List()
    {
        var query = new EmptyQuery<GetTodosResult>();
        var result = await Mediator.Send(query);
        
        result.Should().NotBeNull();
        result.Items.Should()
            .NotBeNull().And
            .BeEmpty();
    }
    
    [Fact]
    public async Task Should_Return_A_Not_Empty_List()
    {
        await Todos.Create(Todo);
        
        var query = new EmptyQuery<GetTodosResult>();
        var result = await Mediator.Send(query);
        
        result.Should().NotBeNull();
        result.Items.Should()
            .NotBeNull().And
            .NotBeEmpty();
    }
}