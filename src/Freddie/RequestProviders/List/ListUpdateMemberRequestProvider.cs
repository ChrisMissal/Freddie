namespace Freddie.RequestProviders.List
{
    internal class ListUpdateMemberRequestProvider : RequestProviderBase
    {
        public ListUpdateMemberRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new BooleanParser(); }
        }
    }
}