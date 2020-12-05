using Application.Commands.DocumentType;
using Application.Commands.Response;
using Domain.Entities;
using Shared.Commands;
using Shared.Handlers;
using Shared.Repositories;

namespace Application.Handlers
{
    public class DocumentTypeHandler : IGenericHandler<DocumentTypeCreateCommand>
    {
        private IGenericRepository<DocumentType> _repository;
        public DocumentTypeHandler(IGenericRepository<DocumentType> repository)
        {
            _repository = repository;
        }
        public IResponseCommand Handle(DocumentTypeCreateCommand command)
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
