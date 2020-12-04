
using Shared.Commands;

namespace Domain.Handlers
{
    public interface IGenericHandler<T> where T : IInputCommand
    {
        IResponseCommand Handle(T command);
    }
}
