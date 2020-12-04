using System;

namespace Shared.Entities
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; protected set; }
        public DateTime UpdatedOn { get; protected set; }
        public bool IsActive { get; protected set; }

        public Entity()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = CreatedOn;
            IsActive = true;
        }

        public void SetUpdateOn(DateTime updateOn)
        {
            UpdatedOn = updateOn;
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
