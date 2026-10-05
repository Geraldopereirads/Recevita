namespace Recevita.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
