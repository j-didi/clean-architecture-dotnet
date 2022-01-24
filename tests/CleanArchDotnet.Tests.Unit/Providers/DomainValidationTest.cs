using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using CleanArchDotnet.Tests.Unit.Common;
using FluentAssertions;
using Xunit;
using static CleanArchDotnet.SharedKernel.DomainValidation.DataContracts.Fail;

namespace CleanArchDotnet.Tests.Unit.Providers;

public class DomainValidationTest: IClassFixture<Fixture>
{
    private readonly IDomainValidationProvider _domainValidation;

    public DomainValidationTest(Fixture fixture)
    {
        _domainValidation = fixture.Get<IDomainValidationProvider>();
    }

    [Fact]
    public void Should_Return_An_Empty_List_When_Dont_Have_Fails_Add()
    {
        _domainValidation.GetFails()
            .Should()
            .BeEmpty();
    }
    
    [Fact]
    public void Should_Return_A_Non_Empty_List_When_Dont_Have_Fails_Add()
    {
        _domainValidation.AddNotFound();
        _domainValidation.GetFails()
            .Should()
            .NotBeEmpty();
    }
    
    [Fact]
    public void Should_Have_A_Single_Fail_Of_Not_Found_Type()
    {
        _domainValidation.AddNotFound();
        _domainValidation.GetFails()
            .Should()
            .HaveCount(1).And
            .ContainSingle(e => e.Type == FailType.NotFound);
    }
    
    [Fact]
    public void Should_Have_A_Single_Fail_Of_Fail_Validation_Type()
    {
        var fail = FailValidation("Fail", "Description");
        _domainValidation.AddFailValidation(fail);
        _domainValidation.GetFails()
            .Should()
            .HaveCount(1).And
            .ContainSingle(e => e.Type == FailType.FailValidation);
    }
    
    [Fact]
    public void Should_Return_True_If_Domain_Validation_Has_Fails()
    {
        _domainValidation.AddNotFound();
        _domainValidation.HasFails()
            .Should()
            .BeTrue();
    }
    
    [Fact]
    public void Should_Return_False_If_Domain_Validation_Has_No_Fails()
    {
        _domainValidation.HasFails()
            .Should()
            .BeFalse();
    }
}