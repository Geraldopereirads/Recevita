using FluentMigrator;

namespace Recevita.Infrastructure.Migrations.Versions;


[Migration(DatabaseVersions.TABLE_USERS, "Criar a tabela para salvar as informações")]
public class Version0000001 : ForwardOnlyMigration
{

    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
            .WithColumn("Name").AsString(250).NotNullable()
            .WithColumn("Email").AsString(250).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable();

    }


}
