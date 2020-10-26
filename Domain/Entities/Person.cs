using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("person")]
    public class Person : Entity
    {
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }

        [Column("name")]
        public string Name { get; private set; }
        [Column("email")]
        public string Email { get; private set; }
    }
}
