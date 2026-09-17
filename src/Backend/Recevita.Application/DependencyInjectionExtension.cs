using Microsoft.Extensions.DependencyInjection;
using Recevita.Application.UseCases.User.Register;

namespace Recevita.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
    }

}
