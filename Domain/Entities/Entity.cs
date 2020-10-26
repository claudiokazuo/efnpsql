using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("createdon")]
        public DateTime CreatedOn { get; protected set; }
        [Column("updatedon")]
        public DateTime UpdatedOn { get; protected set; }
        [Column("isactive")]
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
