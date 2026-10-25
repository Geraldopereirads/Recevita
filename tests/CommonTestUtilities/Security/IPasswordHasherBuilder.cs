using Moq;
using Recevita.Domain.Security.PasswordHashing;

namespace Ismirk.Tests.CommonUtilities.Security;

public class IPasswordHasherBuilder
{
    private readonly Mock<IPasswordHasher> _mock;

    public IPasswordHasherBuilder()
    {

        _mock = new Mock<IPasswordHasher>();



        _mock.Setup(passwordHasher => passwordHasher.HashPassword(It.IsAny<string>())).Returns("hashed_password");

    }

    public void VerifyPassword(string password)
    {


        _mock.Setup(repository => repository.VerifyPassword(password, It.IsAny<string>())).Returns(true);

    }

    public IPasswordHasher Build() => _mock.Object;

}
