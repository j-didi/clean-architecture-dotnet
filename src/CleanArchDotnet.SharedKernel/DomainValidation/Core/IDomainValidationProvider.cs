using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;

namespace CleanArchDotnet.SharedKernel.DomainValidation.Core;

public interface IDomainValidationProvider
{
    IReadOnlyList<Fail> GetFails();
    bool HasFails();
    void AddNotFound(string description = "Not Found!");
    void AddFailValidation(Fail fail);
    void AddFailValidations(IEnumerable<Fail> fails);
    void ClearValidations();
}