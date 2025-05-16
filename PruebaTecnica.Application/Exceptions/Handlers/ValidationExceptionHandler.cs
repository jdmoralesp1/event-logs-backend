using PruebaTecnica.Application.Exceptions.Interfaces;
using PruebaTecnica.Domain.ValueObjects;
using PruebaTecnica.Application.Exceptions.CustomExceptions;

namespace PruebaTecnica.Application.Exceptions.Handlers
{
    public class ValidationExceptionHandler : IExceptionHandler<ValidationException>
    {
        public ValueTask<ProblemDetail> Handle(ValidationException exceptionType) =>
            ValueTask.FromResult(new ProblemDetail
            {
                StatusCode = StatusCode.Status422UnprocessableEntity,
                Type = StatusCode.Status422UnprocessableEntityType,
                Title = "Error en los datos de entrada.",
                Detail = "Se encontraron uno o más errores de validación de datos.",
                InvalidParams = exceptionType.Failures
            });
    }
}
