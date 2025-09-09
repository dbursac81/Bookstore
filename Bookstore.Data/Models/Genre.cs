using Bookstore.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Entities;

public class Genre : BaseEntity
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
