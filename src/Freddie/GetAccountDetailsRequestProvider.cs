namespace Freddie
{
    internal class GetAccountDetailsRequestProvider : RequestProviderBase
    {
        public GetAccountDetailsRequestProvider(Endpoint endpoint) : base(endpoint)
        {
        }

        protected override string Method
        {
            get { return "getAccountDetails"; }
        }
    }
}