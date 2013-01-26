using System;
using Freddie.RequestProviders;
using SpeakEasy;

namespace Freddie
{
    internal class RequestExecutor
    {
        private readonly IHttpClient _client;

        internal RequestExecutor(Uri uri)
        {
            var settings = new HttpClientSettings
                {
                    UserAgent = new UserAgent(UserAgentString),
                };

            _client = HttpClient.Create(uri.AbsoluteUri, settings);
        }

        protected string UserAgentString
        {
            get
            {
                var version = GetType().Assembly.GetName().Version;
                return string.Format("Freddie/{0}.{1}", version.Major, version.Minor);
            }
        }

        internal Response Send(IRequestProvider request)
        {
            var httpRequest = request.GetRequest();

            var resp = _client.Get(httpRequest);

            using (var stream = resp.Body)
            {
                var pair = request.Parser.Parse(stream);
                return pair.Value;
            }
        }
    }
}