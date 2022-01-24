using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using static CleanArchDotnet.SharedKernel.DomainValidation.DataContracts.Fail;

namespace CleanArchDotnet.SharedKernel.DomainValidation.Core;

public class DomainValidationProvider : IDomainValidationProvider
{
    private readonly List<Fail> _fails = new();

    public IReadOnlyList<Fail> GetFails() => _fails.AsReadOnly();

    public bool HasFails() => _fails.Any();

    public void AddNotFound(string description = "Not Found!") =>
        _fails.Add(NotFound(description));
    
    public void AddFailValidation(Fail fail) =>
        _fails.Add(fail);
    
    public void AddFailValidations(IEnumerable<Fail> fails) =>
        _fails.AddRange(fails);

    public void ClearValidations() =>
        _fails.Clear();
}