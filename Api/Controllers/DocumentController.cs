using Application.Commands.Documment;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/document")]
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
        public IEnumerable<Document> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public Document Get(long id)
        {
            return _repository.SearchById(id);
        }

        [HttpPost]
        public ICommandResponse Post([FromBody] DocumentCreateCommand command)
        {
            return _handler.Handle(command);
        }
    }
}