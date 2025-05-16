namespace PruebaTecnica.Infrastructure.UnitOfWork;
public interface IUnitOfWork
{
    Task BeginTransaction();
    Task Rollback();
    Task<int> Save();
}
