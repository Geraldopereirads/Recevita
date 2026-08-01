using Mapster;
using Recevita.Communication.Requests;
using Recevita.Exception.ExeceptionsBase;

namespace Recevita.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase
{
    public void Execute(RequestRegisterUserAccountJson request)
    {
        ValidateAndThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();
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
