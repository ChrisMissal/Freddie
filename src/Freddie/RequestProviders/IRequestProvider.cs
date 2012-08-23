using System.Net.Http;

namespace Freddie.RequestProviders
{
    internal interface IRequestProvider
    {
        HttpRequestMessage GetRequest();

        IResponseParser Parser { get; }
    }
}