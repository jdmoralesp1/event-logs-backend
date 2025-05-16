using PruebaTecnica.Application.Exceptions.Interfaces;
using PruebaTecnica.Domain.ValueObjects;
using System.Reflection;

namespace PruebaTecnica.Application.Exceptions.Services
{
    public class ExceptionHandlerService : IExceptionHandlerService
    {
        public readonly static Dictionary<Type, Type> _exceptionHandlers = new();

        public ExceptionHandlerService(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                IEnumerable<Type> handlers = type.GetInterfaces()
                    .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));

                foreach (var handler in handlers)
                {
                    Type exceptionType = handler.GetGenericArguments()[0];
                    _exceptionHandlers.Add(exceptionType, type);
                }
            }
        }

        public async ValueTask<ProblemDetail> Handle(Exception exceptionType, bool includeDetails)
        {
            ProblemDetail problemDetail;
            if (_exceptionHandlers.TryGetValue(exceptionType.GetType(), out Type? handlerType))
            {
                object? handlerInstance = Activator.CreateInstance(handlerType);
                problemDetail = await (ValueTask<ProblemDetail>)handlerType.GetMethod(nameof(IExceptionHandler<Exception>.Handle))!.Invoke(handlerInstance, new object[]
                {
                exceptionType,
                })!;

                if (!includeDetails)
                {
                    problemDetail.Detail = "Consulte con el adminsitrador.";
                }
            }
            else
            {
                string title, detail;
                if (includeDetails)
                {
                    title = "Error al procesar la respuesta";
                    detail = exceptionType.Message;
                    System.Diagnostics.Debug.WriteLine($"Error al procesar la respuesta: {exceptionType}");
                }
                else
                {
                    title = "Error al procesar la respuesta";
                    detail = "Consulte con el administrador.";
                }
                problemDetail = new ProblemDetail
                {
                    StatusCode = StatusCode.Status500InternalServerError,
                    Type = StatusCode.Status500InternalServerErrorType,
                    Title = title,
                    Detail = detail,
                };
            }

            return problemDetail;
        }
    }
}
