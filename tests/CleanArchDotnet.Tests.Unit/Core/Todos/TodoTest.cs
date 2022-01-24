using System;
using Bogus;
using CleanArchDotnet.Core.Todos;
using FluentAssertions;
using Xunit;

namespace CleanArchDotnet.Tests.Unit.Core.Todos;

public class TodoTest
{
    private readonly Todo _todo;

    public TodoTest()
    {
        var faker = new Faker();
        var description = faker.Lorem.Word();
        _todo = new Todo(description);
    }
    

    [Fact]
    public void Todo_Should_Be_Created_With_Non_Empty_UUID()
    {
        _todo.Id.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public void Todo_Should_Be_Created_With_Created_Status()
    {
        _todo.Status.Should().Be(TodoStatus.Created);
    }
    
    [Fact]
    public void Todo_Should_Be_Marked_As_Done()
    {
        _todo.MarkTodoAsDone();
        _todo.Status.Should().Be(TodoStatus.Done);
    }
    
    [Fact]
    public void Todo_Should_Be_Marked_As_Removed()
    {
        _todo.MarkTodoAsRemoved();
        _todo.Status.Should().Be(TodoStatus.Removed);
    }
}