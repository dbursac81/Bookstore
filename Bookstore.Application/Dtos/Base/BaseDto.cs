namespace Bookstore.Application.Dtos.Base;

public class BaseDto
{
    public Guid Id { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime CreatedDate { get; set; }
}
