using Domain.Commands;

namespace Application.Commands.Documment
{
    public class DocumentCreateCommand : ICommandInput
    {
        public string Number { get; set; }
        public long PersonId { get; set; }
        public long DocumentTypeId { get; set; }
    }
}
