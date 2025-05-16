using Ardalis.GuardClauses;

namespace PruebaTecnica.Application.Features.EventsLog.V1.DTOs;
public class GetAllEventsLogResponse
{
    public int Id { get; private set; }
    public string EventType { get; set; }
    public string Description { get; set; }
    public string CreatedDate { get; set; }
    public string? IpClient { get; set; }

    public GetAllEventsLogResponse(int id, string eventType, string description, string createdDate, string? ipClient)
    {
        Id = Guard.Against.NegativeOrZero(id, nameof(id));
        EventType = Guard.Against.NullOrEmpty(eventType, nameof(eventType));
        Description = Guard.Against.NullOrEmpty(description, nameof(description));
        CreatedDate = Guard.Against.NullOrEmpty(createdDate, nameof(createdDate));
        IpClient = ipClient;
    }
}
