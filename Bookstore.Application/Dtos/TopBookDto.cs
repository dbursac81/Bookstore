namespace Bookstore.Application.Dtos;

public class TopBookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public double AverageRating { get; set; }
}
