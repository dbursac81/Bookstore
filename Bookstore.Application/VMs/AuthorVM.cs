using Bookstore.Application.VMs.Base;

namespace Bookstore.Application.VMs;

public class AuthorVM : BaseVM
{
    public string Name { get; set; }
    public int? YearOfBirth { get; set; }
    public List<BookVM> Books { get; set; } = new List<BookVM>();
}
