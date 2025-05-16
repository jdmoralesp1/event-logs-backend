using MediatR;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Enums;
using PruebaTecnica.Domain.Utils;
using PruebaTecnica.Domain.Wrappers;
using PruebaTecnica.Infrastructure.Repository.Contracts;

namespace PruebaTecnica.Application.Features.EventsLog.V1.Commands.Handlers;
public class CreateEventLogCommandHandler : IRequestHandler<CreateEventLogCommand, Response<string>>
{
    private readonly IEventLogRepository eventLogRepository;

    public CreateEventLogCommandHandler(IEventLogRepository eventLogRepository)
    {
        this.eventLogRepository = eventLogRepository;
    }

    public async Task<Response<string>> Handle(CreateEventLogCommand request, CancellationToken cancellationToken)
    {
        EventLog newEventLog = await eventLogRepository.AddAsync(EventLog.Create(
            eventType: EventType.Api,
            description: request.Description,
            createdDate: TimeUtil.ObtenerFechaYHoraZonaHorariaBogota(),
            ipClient: request.IpClient
        ));

        return new Response<string>(data: $"Se ha creado exitosamente el registro con id {newEventLog.Id}");
    }
}
