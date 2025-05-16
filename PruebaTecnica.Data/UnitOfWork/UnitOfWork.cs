using PruebaTecnica.Infrastructure.Context;

namespace PruebaTecnica.Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly PruebaTecnicaWriteContext context;

    public UnitOfWork(PruebaTecnicaWriteContext context)
    {
        this.context = context;
    }

    public async Task BeginTransaction()
    {
        await context.Database.BeginTransactionAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task Rollback()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public async Task<int> Save() => await context.SaveChangesAsync();
}
