using Application.Commands.Documment;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Handlers;
using Shared.Repositories;

namespace Api.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IGenericRepository<Document> _repository;
        private IGenericHandler<DocumentCreateCommand> _handler;

        public DocumentController(IGenericRepository<Document> repository, IGenericHandler<DocumentCreateCommand> handler)
        {
            _repository = repository;
            _handler = handler;
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
        public IActionResult Post([FromBody] DocumentCreateCommand command)
        {
            return Ok(_handler.Handle(command));
        }
    }
}