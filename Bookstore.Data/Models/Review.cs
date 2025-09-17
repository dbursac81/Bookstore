using Bookstore.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Data.Models;

public class Review : BaseEntity
{
    public Guid BookId { get; set; }

    [ForeignKey(nameof(BookId))]
    public virtual Book? Book { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    [MinLength(1)]
    public string Text { get; set; }
}
