using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Application.Exceptions.Interfaces;
using PruebaTecnica.Application.Features.EventsLog.V1.Queries;
using PruebaTecnica.Application.Features.EventsLog.V1.Validators;

namespace PruebaTecnica.Application.Features.EventsLog.V1;
public static class RegisterValidationsAndServicesEventsLog
{
    public static IServiceCollection AddValidationsAndServicesEventsLog(this IServiceCollection services)
    {
        services.AddScoped<ICustomValidator<GetAllEventsLogQuery>, GetAllEventsLogPersistenceValidator>();

        return services;
    }
}
