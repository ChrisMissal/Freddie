namespace Freddie
{
    [Handles("campaignCreate", typeof(StringParser))]
    [Handles("campaignContent", typeof(ObjectParser))]
    [Handles("campaigns", typeof(ObjectParser))]
    [Handles("campaignDelete", typeof(BooleanParser))]
    [Handles("campaignPause", typeof(BooleanParser))]
    internal class DynamicCampaign : DynamicBase
    {
        internal DynamicCampaign(Endpoint endpoint) : base(endpoint)
        {
        }
    }
}