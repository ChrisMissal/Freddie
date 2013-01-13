namespace Freddie
{
    [Handles("ping", typeof(StringParser))]
    [Handles("getAccountDetails", typeof(ObjectParser))]
    internal class DynamicHelper : DynamicBase
    {
        internal DynamicHelper(Endpoint endpoint) : base(endpoint)
        {
        }
    }
}