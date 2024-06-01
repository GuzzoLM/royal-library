using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.Domain.Services;

public interface IBookService
{
    Task<CollectionResult<Book>> GetAll(BookFilter filter, PagingOptions pagingOptions);

    Task OwnBook(int bookId, bool own);

    Task LoveBook(int bookId, bool love);

    Task WantToReadBook(int bookId, bool wantToRead);
}