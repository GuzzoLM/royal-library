using RoyalLibrary.Domain.Model;
using RoyalLibrary.Domain.Repositories;

namespace RoyalLibrary.Domain.Services;

public class BookService(IBookRepository repository) : IBookService
{
    private const int UserId = 1;

    public Task<CollectionResult<Book>> GetAll(BookFilter filter, PagingOptions pagingOptions)
    {
        filter.UserId = UserId;

        return repository.GetAll(filter, pagingOptions);
    }

    public async Task OwnBook(int bookId, bool own)
    {
        var bookReaction = await repository.GetBookReaction(bookId, UserId);

        if (bookReaction is null)
        {
            bookReaction = new BookReactions();
            await repository.CreateBookReaction(bookReaction);
        }

        bookReaction.Own = own;

        await repository.UpdateBookReaction(bookReaction);
    }

    public async Task LoveBook(int bookId, bool love)
    {
        var bookReaction = await repository.GetBookReaction(bookId, UserId);

        if (bookReaction is null)
        {
            bookReaction = new BookReactions();
            await repository.CreateBookReaction(bookReaction);
        }

        bookReaction.Love = love;

        await repository.UpdateBookReaction(bookReaction);
    }

    public async Task WantToReadBook(int bookId, bool wantToRead)
    {
        var bookReaction = await repository.GetBookReaction(bookId, UserId);

        if (bookReaction is null)
        {
            bookReaction = new BookReactions();
            await repository.CreateBookReaction(bookReaction);
        }

        bookReaction.WantToRead = wantToRead;

        await repository.UpdateBookReaction(bookReaction);
    }
}