using PruebaTecnica.Domain.ValueObjects;

namespace PruebaTecnica.Application.Exceptions.Interfaces
{
    public interface IExceptionHandler<ExceptionType> where ExceptionType : Exception
    {
        ValueTask<ProblemDetail> Handle(ExceptionType exceptionType);
    }
}
