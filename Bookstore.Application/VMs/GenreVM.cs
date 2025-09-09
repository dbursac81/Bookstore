using Bookstore.Application.VMs.Base;

namespace Bookstore.Application.VMs;

public class GenreVM : BaseVM
{
    public string Name { get; set; }
    public List<BookVM> Books { get; set; } = new List<BookVM>();
}
