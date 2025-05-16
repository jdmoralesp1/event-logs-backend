using Ardalis.GuardClauses;
using MediatR;
using PruebaTecnica.Application.Features.EventsLog.V1.DTOs;
using PruebaTecnica.Domain.Enums;
using PruebaTecnica.Domain.Wrappers;

namespace PruebaTecnica.Application.Features.EventsLog.V1.Queries;
public class GetAllEventsLogQuery : IRequest<Response<IEnumerable<GetAllEventsLogResponse>>>
{
    public EventType? EventType { get; set; }
    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }

    public GetAllEventsLogQuery(EventType? eventType, DateTime? initialDate, DateTime? finalDate)
    {
        if(eventType.HasValue)
            EventType = Guard.Against.EnumOutOfRange(eventType.Value, nameof(eventType));
        
        InitialDate = initialDate;
        FinalDate = finalDate;
    }
}
