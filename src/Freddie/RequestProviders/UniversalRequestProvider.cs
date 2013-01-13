namespace Freddie.RequestProviders
{
    internal class UniversalRequestProvider<T> : RequestProviderBase where T : IResponseParser, new()
    {
        private readonly string _method;

        public UniversalRequestProvider(Endpoint endpoint, string method) : base(endpoint)
        {
            _method = method;
        }

        public UniversalRequestProvider(Endpoint endpoint, string method, dynamic args) : base(endpoint)
        {
            _method = method;
            Args = args;
        }

        public override IResponseParser Parser
        {
            get { return new T(); }
        }

        protected override string Method
        {
            get { return _method; }
        }
    }
}