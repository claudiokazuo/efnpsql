using Shared.Commands;

namespace Shared.Handlers
{
    public interface IGenericHandler<T> where T : IInputCommand
    {
        IResponseCommand Handle(T command);
    }
}
