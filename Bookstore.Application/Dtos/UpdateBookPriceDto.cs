namespace Bookstore.Application.Dtos;

public class UpdateBookPriceDto
{
    public Guid BookId { get; set; }
    public decimal Price { get; set; }
}
