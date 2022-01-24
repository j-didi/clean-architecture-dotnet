using CleanArchDotnet.SharedKernel.DomainValidation.Core;
using CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;
using CleanArchDotnet.SharedKernel.DomainValidation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDotnet.API.Common;

[ApiController]
[Route("[controller]")]
public class EndpointController: ControllerBase
{
    private readonly IReadOnlyList<Fail> _fails;

    public EndpointController(IDomainValidationProvider domainValidation)
    {
        _fails = domainValidation.GetFails();
    }

    protected IActionResult Result(object? result = null)
    {
        if (GetNotFoundFail() is { } notFound)
            return NotFound(notFound.Description);

        if (_fails.Any())
            return BadRequest(_fails.PresentFails());

        return result == null ? Ok(): Ok(result);
    }

    private Fail? GetNotFoundFail() => 
        _fails.FirstOrDefault(e => e.Type == FailType.NotFound);
}