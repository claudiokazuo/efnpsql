using Application.Commands.Person;
using Application.Commands.Response;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;

namespace Application.Handlers
{
    public class PersonHandler : IGenericHandler<PersonCreateCommand>,
                                 IGenericHandler<PersonUpdateCommand>
    {
        private IGenericRepository<Person> _repository;

        public PersonHandler(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }

        public ICommandResponse Handle(PersonCreateCommand command)
        {
            Person entity = new Person(command.Name, command.Email);

            _repository.Add(entity);

            return new GenericResponseCommand(true,
                $"{entity.Name} cadastrado",
                entity.Id);
        }

        public ICommandResponse Handle(PersonUpdateCommand command)
        {
            Person entity = _repository.SearchById(command.Id);
            entity.SetIsActive(command.Active);
            _repository.Update(entity);

            return new GenericResponseCommand(true,
                $"Id: {entity.Id} Status: {entity.IsActive}",
                null);
        }
    }
}
