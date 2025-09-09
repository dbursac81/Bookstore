using Bookstore.Data.Interfaces;

namespace Bookstore.Application.VMs.Base;

public class BaseVM : IModifiable, ICreated
{
    public Guid Id { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime CreatedDate { get; set; }
}
