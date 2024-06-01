using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Domain.Model;
using RoyalLibrary.Domain.Services;
using RoyalLibrary.ViewModels;

namespace RoyalLibrary.Controllers;

[Route("[controller]")]
public class BooksController(IMapper mapper, IBookService bookService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]BookFilterViewModel filterViewModel, [FromQuery]PagingOptions pagingOptions)
    {
        var filter = mapper.Map<BookFilter>(filterViewModel);

        var booksResult = await bookService.GetAll(filter, pagingOptions);

        var response = new CollectionResult<BookViewModel>(
            booksResult.Items.Select(mapper.Map<BookViewModel>).ToList(),
            booksResult.Count);

        return Ok(response);
    }

    [HttpPost("own")]
    public async Task<IActionResult> OwnBook([FromBody] BookReactionViewModel viewModel)
    {
        await bookService.OwnBook(viewModel.BookId, viewModel.ReactionValue);

        return NoContent();
    }

    [HttpPost("love")]
    public async Task<IActionResult> LoveBook([FromBody] BookReactionViewModel viewModel)
    {
        await bookService.LoveBook(viewModel.BookId, viewModel.ReactionValue);

        return NoContent();
    }

    [HttpPost("want-to-read")]
    public async Task<IActionResult> WantToReadBook([FromBody] BookReactionViewModel viewModel)
    {
        await bookService.WantToReadBook(viewModel.BookId, viewModel.ReactionValue);

        return NoContent();
    }
}