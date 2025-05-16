using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaTecnica.Application.Exceptions.Interfaces;
using Microsoft.AspNetCore.Builder;
using System.Reflection;
using PruebaTecnica.Application.Exceptions.Services;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace PruebaTecnica.Application.Exceptions
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddExceptionServices(this IServiceCollection services, Assembly assembly)
        {
            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped(typeof(IValidationService<>), typeof(ValidationService<>));

            services.AddSingleton<IExceptionHandlerService>(provider => new ExceptionHandlerService(assembly));

            return services;
        }

        public static IServiceCollection AddExceptionServices(this IServiceCollection services) =>
            AddExceptionServices(services, Assembly.GetExecutingAssembly());

        public static IApplicationBuilder UseExceptionHandlerMiddleware(
    this IApplicationBuilder app,
    IHostEnvironment hostEnvironment,
    IExceptionHandlerService exceptionHandlerService)
        {
            // Middleware personalizado que captura excepciones
            app.Use(async (context, next) =>
            {
                try
                {
                    await next(); // Ejecuta el pipeline
                }
                catch (Exception ex)
                {
                    // Manejo personalizado
                    context.Response.ContentType = "application/json";
                    var problemDetail = await exceptionHandlerService.Handle(ex, hostEnvironment.IsDevelopment());
                    context.Response.StatusCode = problemDetail.StatusCode;
                    await JsonSerializer.SerializeAsync(context.Response.Body, problemDetail);
                }
            });

            // Middleware para errores no capturados (como 404)
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception != null)
                    {
                        context.Response.ContentType = "application/json";
                        var problemDetail = await exceptionHandlerService.Handle(
                            exception,
                            hostEnvironment.IsDevelopment()
                        );
                        context.Response.StatusCode = problemDetail.StatusCode;
                        await JsonSerializer.SerializeAsync(context.Response.Body, problemDetail);
                    }
                }
            });

            return app;
        }
    }
}
