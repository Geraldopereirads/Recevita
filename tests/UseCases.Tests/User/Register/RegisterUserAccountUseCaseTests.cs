using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using Ismirk.Tests.CommonUtilities.Security;
using Recevita.Application.UseCases.User.Register;
using Recevita.Domain.Extensions;
using Recevita.Exception;
using Recevita.Exception.ExeceptionsBase;
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


    private RegisterUserAccountUseCase CreateUseCase(string? emailReadyExist = null)
    {
        var iUnitOfWork = IUnitOfWOrkBuilder.Build();
        var IUserWriteOnlyRepository = IUserWriteOnlyRepositoryBuilder.Build();
        var passwordHasher = new IPasswordHasherBuilder().Build();
        var userReadOnlyRepository = new IUserReadOnlyRepositoryBuilder();

        if (!string.IsNullOrWhiteSpace(emailReadyExist))
        {
            userReadOnlyRepository.ExisteActiveUserWithEmail(emailReadyExist);
        }

        return new RegisterUserAccountUseCase(passwordHasher, IUserWriteOnlyRepository, userReadOnlyRepository.Build(), iUnitOfWork);
    }


    [Fact]
    public async Task WhenNameIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;

        var useCase = CreateUseCase();

        var exception = await useCase.Execute(request).ShouldThrowAsync<ErrorOnValidationException>();


        var errorMessages = exception.GetErrorsMessages();

        errorMessages.Count.ShouldBe(1);

        errorMessages.ShouldContain(ResourceMessagesException.NAME_EMPTY);
    }

    [Fact]
    public async Task ShouldExceptionWhenEmailReadyExist()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        var useCase = CreateUseCase(request.Email);

        var exception = await useCase.Execute(request).ShouldThrowAsync<ErrorOnValidationException>();

        var errorMessages = exception.GetErrorsMessages();

        errorMessages.Count.ShouldBe(1);

        errorMessages.ShouldContain(
            ResourceMessagesException.EMAIL_INVALID);
    }


}
