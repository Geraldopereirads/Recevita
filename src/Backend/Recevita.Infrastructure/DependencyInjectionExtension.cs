using Microsoft.Extensions.DependencyInjection;
using Recevita.Domain.Security.PasswordHashing;
using Recevita.Infrastructure.Security.PasswordHashing;

namespace Recevita.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
    }
}
