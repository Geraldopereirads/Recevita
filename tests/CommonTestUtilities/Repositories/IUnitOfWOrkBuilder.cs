using Moq;
using Recevita.Domain.Repositories;

namespace CommonTestUtilities.Repositories;

public class IUnitOfWOrkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();

        return mock.Object;
    }
}
