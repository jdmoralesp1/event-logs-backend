using PruebaTecnica.Application.Exceptions.Interfaces;
using PruebaTecnica.Application.Features.EventsLog.V1.Queries;
using PruebaTecnica.Infrastructure.Repository.Contracts;

namespace PruebaTecnica.Application.Features.EventsLog.V1.Validators;
public class GetAllEventsLogPersistenceValidator : ICustomValidator<GetAllEventsLogQuery>
{
    public IEnumerable<KeyValuePair<string, string>> Failures { get; private set; } = new List<KeyValuePair<string, string>>();
    private readonly IEventLogRepository eventLogRepository;

    public GetAllEventsLogPersistenceValidator(IEventLogRepository eventLogRepository)
    {
        this.eventLogRepository = eventLogRepository;
    }

    public async ValueTask<bool> Validate(GetAllEventsLogQuery instanceToValidate)
    {
        if(instanceToValidate.InitialDate > instanceToValidate.FinalDate)
            Failures = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("FinalDate", "La fecha inicial no puede ser mayor a la fecha final") };

        var eventLogs = eventLogRepository.GetAll(instanceToValidate.EventType, instanceToValidate.InitialDate, instanceToValidate.FinalDate);

        if (eventLogs == null || !eventLogs.Any())
            Failures = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("EventLog", "No se encontraron registros de eventos") };

        return !Failures.Any();
    }
}
