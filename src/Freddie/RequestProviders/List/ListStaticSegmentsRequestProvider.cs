namespace Freddie.RequestProviders.List
{
    internal class ListStaticSegmentsRequestProvider : RequestProviderBase
    {
        public ListStaticSegmentsRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new ArrayParser(); }
        }
    }
}