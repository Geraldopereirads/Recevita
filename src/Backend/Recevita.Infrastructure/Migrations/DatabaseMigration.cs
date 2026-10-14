using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Ismirk.Infrastructure.Migrations;

public static class DataBaseMigration
{
    public static void Migrate(string connectionString, IServiceProvider serviceProvider)
    {
        EnsureDatabaseCreated(connectionString);
        MigrationDatabase(serviceProvider);
    }

    private static void EnsureDatabaseCreated(string connectionString)
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

        var databaseName = connectionStringBuilder.InitialCatalog;

        connectionStringBuilder.InitialCatalog = "master";

        using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

        dbConnection.Open();

        var databaseAlreadyExists = DatabaseExists(dbConnection, databaseName);

        if (!databaseAlreadyExists)
        {
            dbConnection.Execute($"CREATE DATABASE [{databaseName}]");
        }
    }

    private static bool DatabaseExists(SqlConnection dbConnection, string databaseName)
    {
        const string query = @"
            SELECT 1
            FROM sys.databases
            WHERE name = @name
        ";

        var parameters = new DynamicParameters();

        parameters.Add("name", databaseName);

        var result = dbConnection.QueryFirstOrDefault<int?>(
            query,
            parameters
        );

        return result.HasValue;
    }

    private static void MigrationDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.ListMigrations();
        runner.MigrateUp();
    }
}