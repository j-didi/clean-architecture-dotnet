using Bogus;
using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.Core.Todos;
using CleanArchDotnet.Infra.Database.Context;
using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using CleanArchDotnet.Tests.Integration.Common.Fixtures;
using MediatR;
using Xunit;

namespace CleanArchDotnet.Tests.Integration.Common.Tests;

public class BaseTest: IClassFixture<Fixture> 
{
    protected readonly IMediator Mediator;
    protected readonly ITodos Todos;
    protected readonly Todo Todo;

    protected readonly IDomainValidationProvider DomainValidationProvider;
    protected readonly Faker Faker = new();
        
    protected BaseTest(Fixture fixture)
    {
        Mediator = fixture.Get<IMediator>();
        Todos = fixture.Get<ITodos>();
        Todo = new Todo(Faker.Lorem.Sentence());
        
        DomainValidationProvider = fixture.Get<IDomainValidationProvider>();
        DomainValidationProvider.ClearValidations();
        
        fixture.Get<DatabaseContext>().Database.EnsureDeleted();
    }
}