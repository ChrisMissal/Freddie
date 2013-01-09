namespace Freddie.RequestProviders.List
{
    internal class ListsRequestProvider : RequestProviderBase
    {
        public ListsRequestProvider(Endpoint endpoint) : base(endpoint)
        {
        }

        public ListsRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new ObjectParser(); }
        }
    }
}