using Application.Commands.Create;
using Application.Commands.Response;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;

namespace Application.Handlers
{
    public class PersonHandler : IGenericHandler<PersonCommand>
    {
        private IGenericRepository<Person> _repository;

        public PersonHandler(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }

        public ICommandResponse Handle(PersonCommand command)
        {
            Person entity = new Person(command.Name, command.Email);

            _repository.Add(entity);

            return new GenericResponseCommand(true,
                $"{entity.Name} cadastrado",
                entity.Id);
        }
    }
}
