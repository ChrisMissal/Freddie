using System.Net.Http;

namespace Freddie
{
    internal interface IRequestProvider
    {
        HttpRequestMessage GetRequest();

        IResponseParser Parser { get; }
    }
}