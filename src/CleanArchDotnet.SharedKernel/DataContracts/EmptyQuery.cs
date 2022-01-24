using MediatR;

namespace CleanArchDotnet.SharedKernel.DataContracts;

public record EmptyQuery<T>: IRequest<T>;

public record EmptyResult
{
    private EmptyResult(){}
    public static EmptyResult Create() => new EmptyResult();
}