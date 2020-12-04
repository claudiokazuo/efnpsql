using Shared.Commands;

namespace Application.Commands.Documment
{
    public class DocumentCreateCommand : IInputCommand
    {
        public string Number { get; set; }
        public long PersonId { get; set; }
        public long DocumentTypeId { get; set; }
    }
}
