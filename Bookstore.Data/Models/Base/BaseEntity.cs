

using Bookstore.Data.Interfaces;

namespace Bookstore.Domain.Entities.Base;

public class BaseEntity : IEntity, ICreated, IModifiable, IDeletable
{
    public Guid Id { get; set; }

    private DateTime _createdDate = DateTime.UtcNow;

    public DateTime? DeletedDate { get; set; }

    public DateTime? ModifiedDate { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedDate
    {
        get
        {
            return _createdDate;
        }
        set
        {
            if (value == default(DateTime))
            {
                _createdDate = DateTime.UtcNow;
            }
            else
            {
                _createdDate = value;
            }
        }
    }
}
