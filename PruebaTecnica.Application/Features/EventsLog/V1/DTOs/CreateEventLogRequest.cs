using PruebaTecnica.Domain.Enums;

namespace PruebaTecnica.Application.Features.EventsLog.V1.DTOs;

public record struct CreateEventLogRequest(
    string Description
);