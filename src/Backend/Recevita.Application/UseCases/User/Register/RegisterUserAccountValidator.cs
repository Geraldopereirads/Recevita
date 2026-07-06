using FluentValidation;
using Recevita.Communication.Requests;
using Recevita.Exception;

namespace Recevita.Application.UseCases.User.Register;

public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
        RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceMessagesException.PASSWORD_EMPTY)
            .MinimumLength(8).WithMessage(ResourceMessagesException.PASSWORD_LENGTH);
        When(user => string.IsNullOrWhiteSpace(user.Email) == false, () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
        });
    }
}
