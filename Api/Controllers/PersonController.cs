using Application.Commands.Person;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IGenericRepository<Person> _repository;
        private IGenericHandler<PersonCreateCommand> _handlerCreate;
        private IGenericHandler<PersonUpdateCommand> _handlerUpdate;

        public PersonController(IGenericRepository<Person> repository,
                                IGenericHandler<PersonCreateCommand> handlerCreate,
                                IGenericHandler<PersonUpdateCommand> handlerUpdate)
        {
            _repository = repository;
            _handlerCreate = handlerCreate;
            _handlerUpdate = handlerUpdate;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public Person Get(long id)
        {
            return _repository.SearchById(id);
        }

        [HttpPost]
        public ICommandResponse Post([FromBody] PersonCreateCommand command)
        {
            return _handlerCreate.Handle(command);
        }

        [HttpPut]
        public ICommandResponse Put([FromBody] PersonUpdateCommand command)
        {
            return _handlerUpdate.Handle(command);
        }
    }
}