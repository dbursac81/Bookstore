using Bookstore.Application.Dtos;
using Bookstore.Application.VMs;

namespace Bookstore.Application.Interfaces;

public interface IBookService
{
    public Task<ICollection<BookVM>> GetAllAsync(CancellationToken cancellationToken);
    public Task<ICollection<TopBookDto>> GetTop10Async(CancellationToken cancellationToken);
    public Task UpdatePriceAsync(UpdateBookPriceDto dto, CancellationToken cancellationToken);
}
