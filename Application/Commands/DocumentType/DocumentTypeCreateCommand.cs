using Domain.Commands;

namespace Application.Commands.DocumentType
{
    public class DocumentTypeCreateCommand : ICommandInput
    {
        public string Name { get; set; }
    }
}
