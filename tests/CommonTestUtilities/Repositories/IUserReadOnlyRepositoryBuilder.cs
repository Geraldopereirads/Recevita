using Moq;
using Recevita.Domain.Repositories.User;

namespace CommonTestUtilities.Repositories;

public class IUserReadOnlyRepositoryBuilder
{
	private readonly Mock<IUserReadOnlyRepository> _mock;
    public IUserReadOnlyRepositoryBuilder()
	{
        _mock = new Mock<IUserReadOnlyRepository>();
	}

	public void ExisteActiveUserWithEmail(string email)
    {
        _mock.Setup(repository => repository.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
    }

    public IUserReadOnlyRepository Build() => _mock.Object;
}
