using Shared.Entities;

namespace Domain.Entities
{
    public class Document : Entity
    {
        public Document(string number, long personId, long documentTypeId)
        {
            Number = number;
            PersonId = personId;
            DocumentTypeId = documentTypeId;
        }

        public string Number { get; private set; }
        public long PersonId { get; set; }
        public long DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; private set; }
    }
}
