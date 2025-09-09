using Bookstore.Application.Dtos;
using Bookstore.Application.Interfaces;
using Bookstore.Application.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "ReadPolicy")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize(Policy = "ReadPolicy")]
        public async Task<ActionResult<ICollection<BookVM>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllAsync(cancellationToken);
            return Ok(books);
        }

        [HttpGet("top10")]
        [Authorize(Policy = "ReadPolicy")]
        public async Task<ActionResult<ICollection<TopBookDto>>> GetTop10Async(CancellationToken cancellationToken)
        {
            var top10Books = await _bookService.GetTop10Async(cancellationToken);
            return Ok(top10Books);
        }

        [HttpPut("{id:guid}/price")]
        [Authorize(Policy = "ReadWritePolicy")]
        public async Task<ActionResult> UpdatePriceAsync(Guid id, [FromBody] UpdateBookPriceDto dto, CancellationToken cancellationToken)
        {
            dto.BookId = id;
            await _bookService.UpdatePriceAsync(dto, cancellationToken);
            return Ok();
        }
    }
}
