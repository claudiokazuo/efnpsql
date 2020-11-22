using Application.Commands.Create;
using Application.Commands.Response;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DocumentTypeHandler : IGenericHandler<DocumentTypeCommand>
    {
        private IGenericRepository<DocumentType> _repository;
        public DocumentTypeHandler(IGenericRepository<DocumentType> repository)
        {
            _repository = repository;
        }
        public ICommandResponse Handle(DocumentTypeCommand command)
        {
            DocumentType entity = new DocumentType(command.Name);

            _repository.Add(entity);

            return new GenericResponseCommand(
                true,
                $"{entity.Name} cadastrado", 
                entity.Id);
        }
    }
}
