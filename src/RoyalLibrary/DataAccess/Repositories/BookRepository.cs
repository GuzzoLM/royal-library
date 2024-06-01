using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain.Model;
using RoyalLibrary.Domain.Repositories;

namespace RoyalLibrary.DataAccess.Repositories;

public class BookRepository(LibraryContext context) : IBookRepository
{
    public async Task<CollectionResult<Book>> GetAll(
        BookFilter filter,
        PagingOptions pagingOptions)
    {
        var src = context.Set<Book>();

        var query = Filter(filter, src.AsQueryable());

        var paginatedQuery = query
            .OrderBy(x => x.Title)
            .Skip(pagingOptions.Offset)
            .Take(pagingOptions.Limit);

        var total = await query.CountAsync();

        var items = await paginatedQuery
            .ToListAsync();

        return new CollectionResult<Book>(items, total);
    }

    public async Task<BookReactions?> GetBookReaction(int bookId, int userId)
    {
        var src = context.Set<BookReactions>().AsTracking();

        return await src.Where(x => x.BookId == bookId && x.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task CreateBookReaction(BookReactions bookReactions)
    {
        context.Set<BookReactions>().Add(bookReactions);

        await context.SaveChangesAsync();
    }

    public async Task UpdateBookReaction(BookReactions bookReactions)
    {
        context.Set<BookReactions>().Update(bookReactions);

        await context.SaveChangesAsync();
    }

    private IQueryable<Book> Filter(BookFilter filter, IQueryable<Book> query)
    {
        if (!string.IsNullOrWhiteSpace(filter.Author))
        {
            query = query.Where(x => $"{x.FirstName} {x.LastName}".Contains(filter.Author));
        }

        if (!string.IsNullOrWhiteSpace(filter.Isbn))
        {
            query = query.Where(x => x.Isbn.Contains(filter.Isbn));
        }

        if (filter.Own.HasValue)
        {
            query = query.Where(x => x.BookReactions.Any(br => br.UserId == filter.UserId && br.Own) == filter.Own.Value);
        }

        if (filter.Love.HasValue)
        {
            query = query.Where(x => x.BookReactions.Any(br => br.UserId == filter.UserId && br.Love) == filter.Love.Value);
        }

        if (filter.WantToRead.HasValue)
        {
            query = query.Where(x =>
                x.BookReactions.Any(br => br.UserId == filter.UserId && br.WantToRead) == filter.WantToRead.Value);
        }

        return query;
    }
}