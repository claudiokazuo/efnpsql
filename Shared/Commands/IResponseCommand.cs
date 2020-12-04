namespace Shared.Commands
{
    public interface IResponseCommand
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
