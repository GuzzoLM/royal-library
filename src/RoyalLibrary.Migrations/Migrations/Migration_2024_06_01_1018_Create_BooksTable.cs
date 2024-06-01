using FluentMigrator;

namespace RoyalLibrary.Migrations.Migrations;

[Migration(2024_06_01_1018)]
public class Migration_2024_06_01_1018_Create_BooksTable : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("books")
            .InSchema("dbo")
            .WithColumn("book_id").AsInt32().PrimaryKey()
            .WithColumn("title").AsString(100).NotNullable()
            .WithColumn("first_name").AsString(50).NotNullable()
            .WithColumn("last_name").AsString(50).NotNullable()
            .WithColumn("total_copies").AsInt32().NotNullable()
            .WithColumn("copies_in_use").AsInt32().NotNullable()
            .WithColumn("type").AsString(50).NotNullable()
            .WithColumn("isbn").AsString(80).NotNullable()
            .WithColumn("category").AsString(50).NotNullable();
    }
}