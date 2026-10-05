using Recevita.Domain.Repositories;

namespace Recevita.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly RecevitaDbContext _dbContext;
    public UnitOfWork(RecevitaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();

}
