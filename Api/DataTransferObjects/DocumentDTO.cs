namespace Api.DataTransferObjects
{
    public class DocumentDTO
    {
        public string Number { get; set; }
        public long PersonId { get; set; }
        public long DocumentTypeId { get; set; }
        public DocumentTypeDTO DocumentType { get; private set; }
    }
}
