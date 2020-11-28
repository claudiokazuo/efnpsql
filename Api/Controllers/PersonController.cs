using Application.Commands.Person;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_repository.SearchById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonCreateCommand command)
        {
            return Ok(_handlerCreate.Handle(command));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonUpdateCommand command)
        {
            return Ok(_handlerUpdate.Handle(command));
        }
    }
}