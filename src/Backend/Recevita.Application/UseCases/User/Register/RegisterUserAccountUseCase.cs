using Mapster;
using Recevita.Communication.Requests;
using Recevita.Domain.Repositories;
using Recevita.Domain.Repositories.User;
using Recevita.Domain.Security.PasswordHashing;
using Recevita.Exception.ExeceptionsBase;

namespace Recevita.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserAccountUseCase(
           IPasswordHasher passwordHasher,
           IUserWriteOnlyRepository userWriteOnlyRepository,
           IUnitOfWork unitOfWork
        )
    {
        _passwordHasher = passwordHasher;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(RequestRegisterUserAccountJson request)
    {
        ValidateAndThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();

        user.Password = _passwordHasher.HashPassword(request.Password);
        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();
    }

    private void ValidateAndThrowOnFailures(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ErrorOnValidationException(result.Errors.Select(error => error.ErrorMessage).ToList());
        }

    }
}
