using Application.Commands.Documment;
using Application.Commands.Response;
using Domain.Entities;
using Shared.Commands;
using Shared.Handlers;
using Shared.Repositories;

namespace Application.Handlers
{
    public class DocumentHandler : IGenericHandler<DocumentCreateCommand>
    {
        IGenericRepository<Document> _repository;

        public DocumentHandler(IGenericRepository<Document> repository)
        {
            _repository = repository;
        }

        public IResponseCommand Handle(DocumentCreateCommand command)
        {
            Document entity = new Document(
                command.Number,
                command.PersonId,
                command.DocumentTypeId);

            _repository.Add(entity);

            return new GenericResponseCommand(
                true,
                $"{entity.Number} cadastrado",
                entity.Id);
        }
    }
}
