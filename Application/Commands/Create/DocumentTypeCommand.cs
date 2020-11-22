using Domain.Commands;

namespace Application.Commands.Create
{
    public class DocumentTypeCommand : ICommandInput
    {
        public string Name { get; set; }
    }
}
