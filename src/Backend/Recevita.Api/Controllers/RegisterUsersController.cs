using Microsoft.AspNetCore.Mvc;
using Recevita.Application.UseCases.User.Register;
using Recevita.Communication.Requests;

namespace Recevita.Api.Controllers;

[Route("Users")]
[ApiController]
public class RegisterUsersController : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser(
        [FromBody] RequestRegisterUserAccountJson request,
        [FromServices] IRegisterUserAccountUseCase useCase)
    {
        useCase.Execute(request);

        return Created();
    }
}
