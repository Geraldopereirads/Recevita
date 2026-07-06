using Microsoft.AspNetCore.Mvc;
using Recevita.Application.UseCases.User.Register;
using Recevita.Communication.Requests;

namespace Recevita.Api.Controllers;

[Route("users")]
[ApiController]
public class RegisterUsersController : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser([FromBody]RequestRegisterUserAccountJson request)
    {
        // Registro a conta de uma pessoa
        var useCase = new RegisterUserAccountUseCase();

        useCase.Execute(request);

        return Created();
    }
}
