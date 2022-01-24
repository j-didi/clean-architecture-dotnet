using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bogus;
using CleanArchDotnet.Core.Todos.UseCases.Writes.CreateTodo;
using CleanArchDotnet.Tests.EndToEnd.Common.Factories;
using FluentAssertions;
using Xunit;

namespace CleanArchDotnet.Tests.EndToEnd.Tests;

public class EndpointsTest: IClassFixture<Factory>
{
    private readonly HttpClient _client;
    
    public EndpointsTest(Factory fixture)
    {
        _client = fixture.CreateClient();
    }
    
    [Fact]
    public async Task Should_Return_Ok()
    {
        var response = await _client.GetAsync("/Todo");
        
        response.IsSuccessStatusCode
            .Should()
            .Be(true);
    }
    
    [Fact]
    public async Task Should_Return_NotFound()
    {
        var id = Guid.NewGuid();
        
        var response = await _client.GetAsync($"/Todo/{id}");
        
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }
    
    [Fact]
    public async Task Should_Return_BadRequest()
    {
        var description = new Faker().Lorem.Sentence(256);
        var command = new CreateTodoCommand(description);
        var response = await _client.PostAsJsonAsync($"/Todo", command);
        
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);

        var result = await response
            .Content
            .ReadFromJsonAsync<Dictionary<string, List<string>>>();

        result!.Keys.Count.Should().Be(1);
        result.Values.First().Count.Should().Be(1);
    }
}