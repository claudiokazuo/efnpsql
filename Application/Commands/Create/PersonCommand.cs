using Domain.Commands;

namespace Application.Commands.Create
{
    public class PersonCommand : ICommandInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
