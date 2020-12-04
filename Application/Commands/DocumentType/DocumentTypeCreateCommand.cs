using Shared.Commands;

namespace Application.Commands.DocumentType
{
    public class DocumentTypeCreateCommand : IInputCommand
    {
        public string Name { get; set; }
    }
}
