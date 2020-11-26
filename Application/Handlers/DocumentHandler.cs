using Application.Commands.Documment;
using Application.Commands.Response;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;

namespace Application.Handlers
{
    public class DocumentHandler : IGenericHandler<DocumentCreateCommand>
    {
        IGenericRepository<Document> _repository;

        public DocumentHandler(IGenericRepository<Document> repository)
        {
            _repository = repository;
        }

        public ICommandResponse Handle(DocumentCreateCommand command)
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
