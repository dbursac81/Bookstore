using AutoMapper;
using Bookstore.Application.Dtos;
using Bookstore.Application.Interfaces;
using Bookstore.Application.VMs;
using Bookstore.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Services;

public class BookService : IBookService
{
    private readonly BookstoreContext _context;
    private readonly IMapper _mapper;

    public BookService(BookstoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ICollection<BookVM>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Reviews)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var result = _mapper.Map<ICollection<BookVM>>(query);
        return result;
    }

    public async Task UpdatePriceAsync(UpdateBookPriceDto dto, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == dto.BookId);

        if (book == null)
        {
            throw new KeyNotFoundException($"Book with id {dto.BookId} not found.");
        }

        book.Price = dto.Price;
        book.ModifiedDate = DateTime.UtcNow;

        _context.Update(book);
        await _context.SaveChangesAsync(cancellationToken);

        return;
    }

    public async Task<ICollection<TopBookDto>> GetTop10Async(CancellationToken cancellationToken)
    {
        var sql = @"
                SELECT b.id, b.title,
                       COALESCE(AVG(r.rating), 0) AS averagerating
                FROM books b
                LEFT JOIN reviews r ON r.bookid = b.id
                GROUP BY b.id, b.title
                ORDER BY averagerating DESC
                TOP(10);
            ";

        var top10List = await _context.Set<TopBookDto>().FromSqlRaw(sql).AsNoTracking().ToListAsync();
        return top10List;
    }
}
