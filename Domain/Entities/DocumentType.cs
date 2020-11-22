using System.Collections.Generic;

namespace Domain.Entities
{
    public class DocumentType : Entity
    {
        public DocumentType(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public virtual IList<Document> Documents { get; private set; }
    }
}
