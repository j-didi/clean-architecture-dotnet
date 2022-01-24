using System.Collections.Immutable;
using System.Collections.ObjectModel;
using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using FluentValidation.Results;
using static CleanArchDotnet.SharedKernel.DomainValidation.DataContracts.Fail;

namespace CleanArchDotnet.SharedKernel.DomainValidation.Extensions;

public static class DomainValidationExtensions
{
    public static IReadOnlyList<Fail> GetFails(this ValidationResult result) =>
        result.Errors
            .Select(e => FailValidation(e.ErrorMessage, e.PropertyName))
            .ToImmutableList();

    public static bool HasFails(this ValidationResult result) =>
        !result.IsValid;

    public static Dictionary<string, ReadOnlyCollection<string>> PresentFails(
        this IEnumerable<Fail> fails
    ) => fails
            .GroupBy(e => e.Field)
            .ToDictionary(
                key => key.Key, 
                values => values
                    .Select(e => e.Description)
                    .ToList()
                    .AsReadOnly()
            );
}