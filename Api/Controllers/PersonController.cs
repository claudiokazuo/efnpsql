using Application.Commands.Person;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Handlers;
using Shared.Pagination.Models;
using Shared.Repositories;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/persons")]
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

        [Route("pages")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GenericParameters parameters)
        {
            var result = await _repository.GetAllAsync(parameters);
            Response.Headers.Add("pagination", result.Pagination.ToString());
            return Ok(result.Items);
        }
    }
}