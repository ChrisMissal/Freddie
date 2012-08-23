namespace Freddie
{
    public interface IResponse
    {
        dynamic Content { get; }

        bool Success { get; }
    }
}