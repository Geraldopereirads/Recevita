using Recevita.Domain.Entities;
using Recevita.Domain.Repositories.User;

namespace Recevita.Infrastructure.DataAccess.Repositories;

internal sealed class UserRepositories : IUserWriteOnlyRepository
{
	private readonly RecevitaDbContext _dbContext;
    public UserRepositories(RecevitaDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	
	public async Task Add(User user) => await _dbContext.Users.AddAsync(user);
}
