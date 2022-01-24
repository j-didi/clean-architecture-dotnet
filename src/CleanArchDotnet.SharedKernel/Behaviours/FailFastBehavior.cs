using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using CleanArchDotnet.SharedKernel.DomainValidation.Extensions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanArchDotnet.SharedKernel.Behaviours;

public class FailFastBehavior<TRequest, TResponse> : 
    IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IDomainValidationProvider _domainValidation;

    public FailFastBehavior(
        IEnumerable<IValidator<TRequest>> validators,
        IDomainValidationProvider domainValidation
    )
    {
        _validators = validators;
        _domainValidation = domainValidation;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next
    )
    {
        var fails = GetFails(request);
        if (fails.Any())
        {
            _domainValidation.AddFailValidations(fails);
            return await Task.FromResult<TResponse>(default!);
        }
            
        return await next();
    }

    private List<Fail> GetFails(TRequest request) => 
        _validators
            .Select(validator => validator.Validate(request))
            .Where(HasAnyFail)
            .SelectMany(e => e.GetFails())
            .ToList();

    private static bool HasAnyFail(ValidationResult validationFailure) =>
        validationFailure.Errors != null &&
        validationFailure.Errors.Any();
}