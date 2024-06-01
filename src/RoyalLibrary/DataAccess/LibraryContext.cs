using Microsoft.EntityFrameworkCore;
using RoyalLibrary.DataAccess.Entities;
using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.DataAccess;

public class LibraryContext(DbContextOptions<LibraryContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new BookTypeConfiguration().Configure(modelBuilder.Entity<Book>());
        new BookReactionTypeConfiguration().Configure(modelBuilder.Entity<BookReactions>());
    }
}