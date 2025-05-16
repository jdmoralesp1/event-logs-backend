using PruebaTecnica.Domain.Enums;

namespace PruebaTecnica.Application.Features.EventsLog.V1.DTOs;
public record struct GetAllEventsLogRequest
(
    EventType? EventType,
    DateTime? InitialDate,
    DateTime? FinalDate
);
