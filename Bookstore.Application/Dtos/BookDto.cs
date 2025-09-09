using Bookstore.Application.Dtos.Base;

namespace Bookstore.Application.Dtos;

public  class BookDto : BaseDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string NormalizedTitle { get; set; }
    public ICollection<AuthorDto> Authors { get; set; }
    public ICollection<GenreDto> Genres { get; set; }
    public ICollection<ReviewDto> Reviews { get; set; }
}
