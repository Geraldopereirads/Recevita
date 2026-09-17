using Recevita.Communication.Requests;

namespace Recevita.Application.UseCases.User.Register;

public interface IRegisterUserAccountUseCase
{
    void Execute(RequestRegisterUserAccountJson request);
}
