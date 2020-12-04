using Shared.Entities;

namespace Domain.Entities
{
    public class DocumentType : Entity
    {
        public DocumentType(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
