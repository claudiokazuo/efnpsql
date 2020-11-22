namespace Domain.Entities
{
    public class DocumentType : Entity
    {
        public string Name { get; private set; }

        public virtual Document Document { get; private set; }
    }
}
