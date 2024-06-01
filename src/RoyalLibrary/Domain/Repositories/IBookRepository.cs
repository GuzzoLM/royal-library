using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.Domain.Repositories;

public interface IBookRepository
{
    Task<CollectionResult<Book>> GetAll(BookFilter filter, PagingOptions pagingOptions);

    Task<BookReactions?> GetBookReaction(int bookId, int userId);

    Task CreateBookReaction(BookReactions bookReactions);

    Task UpdateBookReaction(BookReactions bookReactions);
}