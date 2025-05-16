using MediatR;
using PruebaTecnica.Application.Exceptions.Interfaces;
using PruebaTecnica.Application.Features.EventsLog.V1.DTOs;
using PruebaTecnica.Domain.Enums.Extensions;
using PruebaTecnica.Domain.Utils;
using PruebaTecnica.Domain.Wrappers;
using PruebaTecnica.Infrastructure.Repository.Contracts;

namespace PruebaTecnica.Application.Features.EventsLog.V1.Queries.Handlers;
public class GetAllEventsLogQueryHandler : IRequestHandler<GetAllEventsLogQuery, Response<IEnumerable<GetAllEventsLogResponse>>>
{
    private readonly IValidationService<GetAllEventsLogQuery> validationService;
    private readonly IEventLogRepository eventLogRepository;

    public GetAllEventsLogQueryHandler(IValidationService<GetAllEventsLogQuery> validationService, IEventLogRepository eventLogRepository)
    {
        this.validationService = validationService;
        this.eventLogRepository = eventLogRepository;
    }

    public async Task<Response<IEnumerable<GetAllEventsLogResponse>>> Handle(GetAllEventsLogQuery request, CancellationToken cancellationToken)
    {
        await validationService.ExecuteValidationGuard(request);

        var eventLogs = eventLogRepository.GetAll(request.EventType, request.InitialDate, request.FinalDate);

        var eventsLogResponse = eventLogs!.Select(x =>
            new GetAllEventsLogResponse
            (
                id: x.Id,
                eventType: (x.EventType).GetDescription(),
                description: x.Description,
                createdDate: TimeUtil.GetDateInFormatYYYYmmddHHmm(x.CreatedDate),
                ipClient: x.IpClient
            )
        );

        return new Response<IEnumerable<GetAllEventsLogResponse>>(eventsLogResponse);
    }
}
