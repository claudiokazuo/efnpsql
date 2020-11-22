namespace Domain.Entities
{
    public class Document : Entity
    {
        public string Number { get; private set; }
        public long PersonId { get; set; }
        public long DocumentTypeId { get; set; }
        public virtual Person Person { get; private set; }
        public virtual DocumentType DocumentType { get; private set; }
    }
}
