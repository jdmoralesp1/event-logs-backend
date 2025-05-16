using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Infrastructure.Context;
public class PruebaTecnicaReadContext : DbContext
{
    public PruebaTecnicaReadContext(DbContextOptions<PruebaTecnicaReadContext> options) : base(options) { }

    public DbSet<EventLog> EventLogs { get; set; }
}
