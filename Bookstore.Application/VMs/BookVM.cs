using Bookstore.Application.VMs.Base;

namespace Bookstore.Application.VMs;

public class BookVM : BaseVM
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string? NormalizedTitle { get; set; }
    public List<AuthorVM> Authors { get; set; } = new List<AuthorVM>();
    public List<GenreVM> Genres { get; set; } = new List<GenreVM>();
    public List<ReviewVM> Reviews { get; set; } = new List<ReviewVM>();
}
