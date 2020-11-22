using Domain.Commands;

namespace Application.Commands.Create
{
    public class PersonCommand : ICommandInput
    {
        public PersonCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
