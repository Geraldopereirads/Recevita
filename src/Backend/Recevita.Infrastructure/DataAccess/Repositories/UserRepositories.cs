using Microsoft.EntityFrameworkCore;
using Recevita.Domain.Entities;
using Recevita.Domain.Repositories.User;

namespace Recevita.Infrastructure.DataAccess.Repositories;

internal sealed class UserRepositories : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly RecevitaDbContext _dbContext;
    public UserRepositories(RecevitaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(user => user.Active && user.Email.Equals(email));
}
