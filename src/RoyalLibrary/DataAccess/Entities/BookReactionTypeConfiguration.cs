using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.DataAccess.Entities;

public class BookReactionTypeConfiguration : IEntityTypeConfiguration<BookReactions>
{
    public void Configure(EntityTypeBuilder<BookReactions> builder)
    {
        builder.ToTable("books_reactions");

        builder.HasKey(e => e.Id);

        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.BookReactions)
            .HasForeignKey(x => x.BookId);

        builder.Property(e => e.Id).HasColumnName("books_reaction_id");
        builder.Property(e => e.BookId).HasColumnName("book_id");
        builder.Property(e => e.UserId).HasColumnName("user_id");
        builder.Property(e => e.Love).HasColumnName("love");
        builder.Property(e => e.Own).HasColumnName("own");
        builder.Property(e => e.WantToRead).HasColumnName("want_to_read");
    }
}