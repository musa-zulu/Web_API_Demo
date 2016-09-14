using FluentMigrator;

namespace Web_API_Demo.DB.Migrations.Migrations
{
    [Migration(201609141433)]
    public class _201609141433_InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table(DBConstants.Tables.ProductTable.TableName)
                .WithColumn(DBConstants.Tables.ProductTable.Columns.Id).AsInt16().PrimaryKey()
                .WithColumn(DBConstants.Tables.ProductTable.Columns.Name).AsString(512)
                .WithColumn(DBConstants.Tables.ProductTable.Columns.Type).AsString(30)
                .WithColumn(DBConstants.Tables.ProductTable.Columns.Description).AsString(int.MaxValue)
                .WithColumn(DBConstants.Tables.ProductTable.Columns.Price).AsDecimal(19,2).Nullable();          
        }

        public override void Down()
        {
        }
    }
}
