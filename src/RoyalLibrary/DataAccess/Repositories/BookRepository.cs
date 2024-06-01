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

        var filterExpression = ToExpression(filter);

        var query = src.Where(filterExpression);

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

    private Expression<Func<Book, bool>> ToExpression(BookFilter filter)
    {
        Expression<Func<Book, bool>> expression = x => true;

        if (!string.IsNullOrWhiteSpace(filter.Author))
        {
            Expression<Func<Book, bool>> andExpression = x => $"{x.FirstName} {x.LastName}".Contains(filter.Author);
            expression = Expression.Lambda<Func<Book, bool>>(Expression.AndAlso(expression, andExpression));
        }

        if (!string.IsNullOrWhiteSpace(filter.Isbn))
        {
            Expression<Func<Book, bool>> andExpression = x => x.Isbn.Contains(filter.Isbn);
            expression = Expression.Lambda<Func<Book, bool>>(Expression.AndAlso(expression, andExpression));
        }

        if (filter.Own.HasValue)
        {
            Expression<Func<Book, bool>> andExpression = x => x.BookReactions.Any(br => br.UserId == filter.UserId && br.Own == filter.Own.Value);
            expression = Expression.Lambda<Func<Book, bool>>(Expression.AndAlso(expression, andExpression));
        }

        if (filter.Love.HasValue)
        {
            Expression<Func<Book, bool>> andExpression = x => x.BookReactions.Any(br => br.UserId == filter.UserId && br.Love == filter.Love.Value);
            expression = Expression.Lambda<Func<Book, bool>>(Expression.AndAlso(expression, andExpression));
        }

        if (filter.WantToRead.HasValue)
        {
            Expression<Func<Book, bool>> andExpression = x => x.BookReactions.Any(br => br.UserId == filter.UserId && br.WantToRead == filter.WantToRead.Value);
            expression = Expression.Lambda<Func<Book, bool>>(Expression.AndAlso(expression, andExpression));
        }

        return expression;
    }
}