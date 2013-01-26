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
            _client = HttpClient.Create(uri.AbsoluteUri);
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