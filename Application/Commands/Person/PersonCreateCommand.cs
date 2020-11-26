using Domain.Commands;

namespace Application.Commands.Person
{
    public class PersonCreateCommand : ICommandInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
