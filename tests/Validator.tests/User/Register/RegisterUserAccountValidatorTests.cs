using CommonTestUtilities.Requests;
using Recevita.Application.UseCases.User.Register;
using Recevita.Exception;
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

    [Fact]
    public void Validate_Is_Name_Empty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.Count.ShouldBe(1);

        result.Errors.ShouldContain(error =>
    error.ErrorMessage == ResourceMessagesException.NAME_EMPTY);


    }


    [Fact]
    public void Validate_Is_Email_Empty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.Count.ShouldBe(1);

        result.Errors.ShouldContain(error =>
            error.ErrorMessage == ResourceMessagesException.EMAIL_EMPTY);
    }

    [Fact]
    public void Validate_Is_Email_Invalid()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = "seila.com";

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();

        result.Errors.Count.ShouldBe(1);

        result.Errors.ShouldContain(error =>
    error.ErrorMessage == ResourceMessagesException.EMAIL_INVALID);


    }


    [Fact]
    public void Validate_Is_Password_Empty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Password = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(2);
        result.Errors.ShouldContain(error => error.ErrorMessage == ResourceMessagesException.PASSWORD_EMPTY);
    }


}
