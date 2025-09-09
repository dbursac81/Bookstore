using Bookstore.Application.Dtos.Base;

namespace Bookstore.Application.Dtos;

public class GenreDto : BaseDto
{
    public string Name { get; set; }
    public ICollection<BookDto> Books { get; set; }
}
