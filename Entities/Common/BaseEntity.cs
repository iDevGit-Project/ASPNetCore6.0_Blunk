using System;

namespace Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
    }

    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
        public BaseEntity()
        {
            IsActive = true;
            CreationDate = DateTime.Now;
        }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {

    }
}
