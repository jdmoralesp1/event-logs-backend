using PruebaTecnica.Domain.Enums;

namespace PruebaTecnica.Domain.Entities;

public class EventLog
{
    public int Id { get; private set; }
    public EventType EventType { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public string? IpClient { get; private set; }

    public EventLog(EventType eventType, string description, DateTime createdDate, string? ipClient)
    {
        EventType = eventType;
        Description = description;
        CreatedDate = createdDate;
        IpClient = ipClient;
    }

    public static EventLog Create(EventType eventType, string description, DateTime createdDate, string? ipClient)
    {
        return new EventLog
        (
            eventType: eventType,
            description: description,
            createdDate: createdDate,
            ipClient: ipClient
        );
    }
}