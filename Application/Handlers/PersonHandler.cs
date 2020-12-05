using Application.Commands.Person;
using Application.Commands.Response;
using Domain.Entities;
using Shared.Commands;
using Shared.Handlers;
using Shared.Repositories;

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

        public IResponseCommand Handle(PersonCreateCommand command)
        {
            Person entity = new Person(command.Name, command.Email);

            _repository.Add(entity);

            return new GenericResponseCommand(true,
                $"{entity.Name} cadastrado",
                entity.Id);
        }

        public IResponseCommand Handle(PersonUpdateCommand command)
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
