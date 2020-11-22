using Domain.Commands;

namespace Application.Commands.Create
{
    public class DocumentCommand : ICommandInput
    {
        public string Number { get; set; }
        public long PersonId { get; set; }
        public long DocumentTypeId { get; set; }
    }
}
