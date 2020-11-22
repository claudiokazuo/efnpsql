using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Create;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IGenericRepository<Document> _repository;
        private IGenericHandler<Application.Commands.Create.DocumentCommand> _handler;

        public DocumentController(IGenericRepository<Document> repository, IGenericHandler<DocumentCommand> handler)
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
        public ICommandResponse Post([FromBody] Application.Commands.Create.DocumentCommand command)
        {
            return _handler.Handle(command);
        }
    }
}