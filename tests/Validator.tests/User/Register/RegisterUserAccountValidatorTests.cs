using CommonTestUtilities.Requests;
using Recevita.Application.UseCases.User.Register;
using Shouldly;

namespace Validator.tests.User.Register;

public class RegisterUserAccountValidatorTests
{
    [Fact]
    public void Success()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }
}
