namespace Freddie.RequestProviders.Campaign
{
    internal class CampaignDeleteRequestProvider : RequestProviderBase
    {
        public CampaignDeleteRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new BooleanParser(); }
        }
    }
}