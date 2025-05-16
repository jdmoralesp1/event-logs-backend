using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PruebaTecnica.Application.Exceptions.Interfaces;
using PruebaTecnica.Domain.ValueObjects;
using System.Text.Json;

namespace PruebaTecnica.Application.Exceptions.Services
{
    public class ExceptionHandlerMiddleware
    {
        public static async Task WriteResponse(HttpContext context, bool includeDetails, IExceptionHandlerService handler)
        {
            IExceptionHandlerFeature exceptionDetail = context.Features.Get<IExceptionHandlerFeature>();

            Exception exception = exceptionDetail.Error;

            if (exception != null)
            {
                ProblemDetail problemDetail = await handler.Handle(exception, includeDetails);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = problemDetail.StatusCode;

                Stream stream = context.Response.Body;
                await JsonSerializer.SerializeAsync(stream, problemDetail);
            }
        }
    }
}
