using Shared.Commands;

namespace Application.Commands.Person
{
    public class PersonCreateCommand : IInputCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
