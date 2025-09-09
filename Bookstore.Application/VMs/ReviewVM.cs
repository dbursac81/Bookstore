using Bookstore.Application.VMs.Base;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Application.VMs;

public class ReviewVM : BaseVM
{
    public BookVM Book { get; set; } = new BookVM();
      
    public int Rating { get; set; }

    public string? Text { get; set; }
}
