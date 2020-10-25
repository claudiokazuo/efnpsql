using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("person")]
    public class Person : Entity
    {        
        [Column("name")]
        public string Name { get; private set; }
        [Column("email")]
        public string Email { get; private set; }

        public Person()
        {

        }

        public Person(
            string name, 
            string email,                      
            bool isActive)
        {
            Name = name;
            Email = email;
            CreatedOn = DateTime.Now;
            UpdatedOn = CreatedOn;
            IsActive = isActive;
        }
    }
}
