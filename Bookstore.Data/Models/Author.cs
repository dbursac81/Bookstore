

using Bookstore.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Entities;

public class Author : BaseEntity
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    public int? YearOfBirth { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
