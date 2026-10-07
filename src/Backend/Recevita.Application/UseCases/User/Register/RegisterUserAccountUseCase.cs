using FluentValidation.Results;
using Mapster;
using Recevita.Communication.Requests;
using Recevita.Communication.Responses;
using Recevita.Domain.Repositories;
using Recevita.Domain.Repositories.User;
using Recevita.Domain.Security.PasswordHashing;
using Recevita.Exception.ExeceptionsBase;

namespace Recevita.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserAccountUseCase(
           IPasswordHasher passwordHasher,
           IUserWriteOnlyRepository userWriteOnlyRepository,
           IUserReadOnlyRepository userReadOnlyRepository,
           IUnitOfWork unitOfWork
        )
    {
        _passwordHasher = passwordHasher;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserAccountJson request)
    {
        await ValidateAndThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();

        user.Password = _passwordHasher.HashPassword(request.Password);
        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return new ResponseRegisterUserJson
        {
            Name = user.Name
        };
    }

    private async Task ValidateAndThrowOnFailures(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, "Email já Existe."));
        }

        if (!result.IsValid)
        {
            throw new ErrorOnValidationException(result.Errors.Select(error => error.ErrorMessage).ToList());
        }

    }
}
