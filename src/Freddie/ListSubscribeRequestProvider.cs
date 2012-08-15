namespace Freddie
{
    internal class ListsRequestProvider : RequestProviderBase
    {
        public ListsRequestProvider(Endpoint endpoint) : base(endpoint)
        {
        }

        public ListsRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        protected override string Method
        {
            get { return "lists"; }
        }
    }

    internal class ListSubscribeRequestProvider : RequestProviderBase
    {
        public ListSubscribeRequestProvider(Endpoint endpoint, dynamic args) : base(endpoint)
        {
            Args = args;
        }

        protected override string Method
        {
            get { return "listSubscribe"; }
        }
    }
}