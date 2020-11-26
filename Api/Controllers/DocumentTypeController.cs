using Application.Commands.DocumentType;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/documenttype")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private IGenericRepository<DocumentType> _repository;
        private IGenericHandler<DocumentTypeCreateCommand> _handler;

        public DocumentTypeController(IGenericRepository<DocumentType> repository, IGenericHandler<DocumentTypeCreateCommand> handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        public IEnumerable<DocumentType> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public DocumentType Get(long id)
        {
            return _repository.SearchById(id);
        }

        [HttpPost]
        public ICommandResponse Post([FromBody] DocumentTypeCreateCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
