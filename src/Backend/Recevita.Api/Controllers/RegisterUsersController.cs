using Microsoft.AspNetCore.Mvc;
using Recevita.Application.UseCases.User.Register;
using Recevita.Communication.Requests;
using Recevita.Communication.Responses;

namespace Recevita.Api.Controllers;

[Route("Users")]
[ApiController]
public class RegisterUsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterUser(
        [FromBody] RequestRegisterUserAccountJson request,
        [FromServices] IRegisterUserAccountUseCase useCase)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
