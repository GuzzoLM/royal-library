using FluentMigrator;

namespace RoyalLibrary.Migrations.Migrations;

[Migration(2024_06_01_1044)]
public class Migration_2024_06_01_1044_Create_BookReactionsTable : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("books_reactions")
            .InSchema("dbo")
            .WithColumn("books_reaction_id").AsInt32().PrimaryKey()
            .WithColumn("book_id").AsInt32().NotNullable().ForeignKey("books", "book_id")
            .WithColumn("user_id").AsInt32().NotNullable()
            .WithColumn("own").AsBoolean().NotNullable()
            .WithColumn("love").AsBoolean().NotNullable()
            .WithColumn("want_to_read").AsBoolean().NotNullable();
    }
}