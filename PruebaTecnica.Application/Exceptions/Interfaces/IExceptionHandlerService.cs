using PruebaTecnica.Domain.ValueObjects;

namespace PruebaTecnica.Application.Exceptions.Interfaces
{
    public interface IExceptionHandlerService
    {
        ValueTask<ProblemDetail> Handle(Exception exceptionType, bool includeDetails);
    }
}
