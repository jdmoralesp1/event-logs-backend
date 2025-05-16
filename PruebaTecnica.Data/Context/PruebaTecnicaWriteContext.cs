using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Enums;
using PruebaTecnica.Domain.Utils;

namespace PruebaTecnica.Infrastructure.Context
{
    public class PruebaTecnicaWriteContext : DbContext
    {
        public PruebaTecnicaWriteContext(DbContextOptions<PruebaTecnicaWriteContext> options) : base(options) { }

        public DbSet<EventLog> EventLogs { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            EventLogs.Add(EventLog.Create(
                eventType: EventType.FormularioDeEventosManuales,
                description: "Evento Automatico del sistema",
                createdDate: TimeUtil.ObtenerFechaYHoraZonaHorariaBogota(),
                ipClient: null
            ));

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
