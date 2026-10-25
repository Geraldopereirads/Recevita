using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using Ismirk.Tests.CommonUtilities.Security;
using Recevita.Application.UseCases.User.Register;
using Shouldly;

namespace UseCases.Tests.User.Register;

public class RegisterUserAccountUseCaseTests
{
    [Fact]

    public async Task Success()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        CreateUseCase();

        var result = await CreateUseCase().Execute(request);

        result.ShouldNotBeNull();
        result.Tokens.ShouldNotBeNull();
        result.Name.ShouldBe(request.Name);
        // TODO: Validar AccessToken e RefreshToken após implementação da autenticação JWT.
    }


    private RegisterUserAccountUseCase CreateUseCase()
    {
        var iUnitOfWork = IUnitOfWOrkBuilder.Build();
        var IUserWriteOnlyRepository = IUserWriteOnlyRepositoryBuilder.Build();
        var passwordHasher = new IPasswordHasherBuilder().Build();
        var userReadOnlyRepository = new IUserReadOnlyRepositoryBuilder().Build();

        return new RegisterUserAccountUseCase(passwordHasher, IUserWriteOnlyRepository, userReadOnlyRepository, iUnitOfWork);
    }
}
