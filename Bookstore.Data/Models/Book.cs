using Bookstore.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Data.Models;

public class Book : BaseEntity
{
    [Required]
    public string Title { get; set; }
    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public string? NormalizedTitle { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}
