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
        public DateTime CreatedOn { get; set; }
        [Column("updatedon")]
        public DateTime UpdatedOn { get; set; }
        [Column("isactive")]
        public bool IsActive { get; set; }
    }
}
