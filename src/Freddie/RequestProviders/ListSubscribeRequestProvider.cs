namespace Freddie.RequestProviders
{
    internal class ListSubscribeRequestProvider : RequestProviderBase
    {
        public ListSubscribeRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new BooleanParser(); }
        }
    }
}