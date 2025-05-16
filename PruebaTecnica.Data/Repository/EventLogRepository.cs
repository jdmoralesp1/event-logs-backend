using PruebaTecnica.Infrastructure.Context;
using PruebaTecnica.Infrastructure.Repository.Contracts;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Infrastructure.Repository
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly PruebaTecnicaReadContext readContext;
        private readonly PruebaTecnicaWriteContext writeContext;

        public EventLogRepository(PruebaTecnicaReadContext readContext, PruebaTecnicaWriteContext writeContext)
        {
            this.readContext = readContext;
            this.writeContext = writeContext;
        }

        public IEnumerable<EventLog>? GetAll(EventType? eventType, DateTime? initialDate, DateTime? finalDate)
        {
            return readContext.Set<EventLog>()
                .AsNoTracking()
                .Where(
                    x => 
                        (!eventType.HasValue || x.EventType == eventType) &&
                        (!initialDate.HasValue || x.CreatedDate >= initialDate.Value.Date) &&
                        (!finalDate.HasValue || x.CreatedDate <= finalDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                );
        }

        public async Task<EventLog> AddAsync(EventLog eventLog)
        {
            writeContext.EventLogs.Add(eventLog);
            await writeContext.SaveChangesAsync();
            return eventLog;
        }
    }
}
