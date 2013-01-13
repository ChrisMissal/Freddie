namespace Freddie.RequestProviders.Campaign
{
    internal class CampaignContentRequestProvider : RequestProviderBase
    {
        public CampaignContentRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new ObjectParser(); }
        }
    }
}