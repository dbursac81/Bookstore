using Bookstore.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Data.Models;

public class Genre : BaseEntity
{
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
