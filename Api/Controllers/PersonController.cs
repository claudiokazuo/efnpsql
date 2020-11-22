using Application.Commands.Create;
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
        private IGenericHandler<Application.Commands.Create.PersonCommand> _handler;

        public PersonController(IGenericRepository<Person> repository, IGenericHandler<PersonCommand> handler)
        {
            _repository = repository;
            _handler = handler;
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
        public ICommandResponse Post([FromBody] Application.Commands.Create.PersonCommand command)
        {
            return _handler.Handle(command);
        }
    }
}