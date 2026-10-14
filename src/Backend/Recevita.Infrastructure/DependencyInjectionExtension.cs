using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recevita.Domain.Repositories;
using Recevita.Domain.Repositories.User;
using Recevita.Domain.Security.PasswordHashing;
using Recevita.Infrastructure.DataAccess;
using Recevita.Infrastructure.DataAccess.Repositories;
using Recevita.Infrastructure.Security.PasswordHashing;
using System.Reflection;

namespace Recevita.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepositories>();
            services.AddScoped<IUserReadOnlyRepository, UserRepositories>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<RecevitaDbContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("ConnectionSQLServer")!;
                config.UseSqlServer(connectionString);
            });


            services.AddFluentMigratorCore().ConfigureRunner(config =>
            {
                var connectionString = configuration.GetConnectionString("ConnectionSQLServer")!;

                config.AddSqlServer().WithGlobalConnectionString(connectionString).ScanIn(Assembly.Load("Recevita.Infrastructure")).For.All();
            });
        }
    }
}
