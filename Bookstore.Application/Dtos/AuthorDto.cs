using Bookstore.Application.Dtos.Base;

namespace Bookstore.Application.Dtos;

public class AuthorDto : BaseDto
{
    public string Name { get; set; }
    public int? YearOfBirth { get; set; }
    public ICollection<BookDto> Books { get; set; }
}
