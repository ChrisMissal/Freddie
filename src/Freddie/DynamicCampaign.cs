using Freddie.RequestProviders.Campaign;

namespace Freddie
{
    internal class DynamicCampaign : DynamicBase
    {
        internal DynamicCampaign(Endpoint endpoint) : base(endpoint)
        {
            methods.Add("campaignCreate", typeof(CampaignCreateRequestProvider));
        }
    }
}