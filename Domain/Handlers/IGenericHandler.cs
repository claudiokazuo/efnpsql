using Domain.Commands;

namespace Domain.Handlers
{
    public interface IGenericHandler<T> where T: ICommandInput
    {
       ICommandResponse Handle(T command);
    }
}
