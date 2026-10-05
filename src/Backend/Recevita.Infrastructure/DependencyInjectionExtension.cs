using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recevita.Domain.Repositories;
using Recevita.Domain.Repositories.User;
using Recevita.Domain.Security.PasswordHashing;
using Recevita.Infrastructure.DataAccess;
using Recevita.Infrastructure.DataAccess.Repositories;
using Recevita.Infrastructure.Security.PasswordHashing;

namespace Recevita.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepositories>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<RecevitaDbContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("ConnectionSQLServer")!;
                config.UseSqlServer(connectionString);
            });
        }
    }
}
