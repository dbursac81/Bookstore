namespace Bookstore.Data.Interfaces;

public interface IDeletable
{
    public bool IsDeleted { get; set; }

    DateTime? DeletedDate { get; set; }
}
