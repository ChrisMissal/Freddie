namespace Freddie
{
    [Handles("listUpdateMember", typeof(BooleanParser))]
    [Handles("listStaticSegments", typeof(ArrayParser))]
    [Handles("listSubscribe", typeof(BooleanParser))]
    [Handles("lists", typeof(ObjectParser))]
    internal class DynamicList : DynamicBase
    {
        internal DynamicList(Endpoint endpoint) : base(endpoint)
        {
        }
    }
}