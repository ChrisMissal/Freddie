using System.Net.Http;
using System.Net.Http.Headers;

namespace Freddie
{
    internal class RequestExecutor
    {
        private readonly HttpClient _client;

        internal RequestExecutor()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal Response Send(IRequestProvider request)
        {
            var requestMessage = request.GetRequest();
            using (var resp = _client.SendAsync(requestMessage).Result)
            {
                if (!resp.IsSuccessStatusCode)
                    ThrowHelper.Message("[{0}] ({1})", (int)resp.StatusCode, resp.ReasonPhrase);

                using (var stream = resp.Content.ReadAsStreamAsync().Result)
                    return request.Parser.Parse(stream);
            }
        }
    }
}