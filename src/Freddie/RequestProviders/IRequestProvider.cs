namespace Freddie.RequestProviders
{
    internal interface IRequestProvider
    {
        string GetRequest();

        IResponseParser Parser { get; }
    }
}