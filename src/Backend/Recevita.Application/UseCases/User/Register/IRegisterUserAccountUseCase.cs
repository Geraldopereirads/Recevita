using Recevita.Communication.Requests;
using Recevita.Communication.Responses;

namespace Recevita.Application.UseCases.User.Register;

public interface IRegisterUserAccountUseCase
{
    Task<ResponseRegisterUserJson> Execute(RequestRegisterUserAccountJson request);
}
