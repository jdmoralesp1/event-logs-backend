using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Enums;

namespace PruebaTecnica.Infrastructure.Repository.Contracts;
public interface IEventLogRepository
{
    public IEnumerable<EventLog>? GetAll(EventType? eventType, DateTime? initialDate, DateTime? finalDate);
    public Task<EventLog> AddAsync(EventLog eventLog);
}
