using Shared.Commands;

namespace Application.Commands.Person
{
    public class PersonUpdateCommand : IInputCommand
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
