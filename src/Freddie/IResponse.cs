using Newtonsoft.Json.Linq;

namespace Freddie
{
    public interface IResponse
    {
        JToken Content { get; }

        bool Success { get; }
    }
}