using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.DataAccess.Entities;

public class BookTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("book_id");
        builder.Property(e => e.FirstName).HasColumnName("first_name");
        builder.Property(e => e.LastName).HasColumnName("last_name");
        builder.Property(e => e.Title).HasColumnName("title");
        builder.Property(e => e.TotalCopies).HasColumnName("total_copies");
        builder.Property(e => e.CopiesInUse).HasColumnName("copies_in_use");
        builder.Property(e => e.Type).HasColumnName("type");
        builder.Property(e => e.Isbn).HasColumnName("isbn");
        builder.Property(e => e.Category).HasColumnName("category");
    }
}