using Bookstore.Application.Dtos.Base;

namespace Bookstore.Application.Dtos;

public class ReviewDto : BaseDto
{    
    public BookDto Book { get; set; }
    public int Rating { get; set; }
    public string Text { get; set; }
}
