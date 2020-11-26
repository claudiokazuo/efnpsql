using Domain.Commands;

namespace Application.Commands.Person
{
    public class PersonUpdateCommand : ICommandInput
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
