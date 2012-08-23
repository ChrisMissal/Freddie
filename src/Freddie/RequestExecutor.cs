using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Freddie.RequestProviders;

namespace Freddie
{
    internal class Logger
    {
        internal static void Log(string request, string response)
        {
            File.AppendAllLines(@"C:\freddie.txt", new[] { DateTime.Now.ToString(CultureInfo.InvariantCulture), request, "", response, "" });
        }

        internal static void Log(Exception ex)
        {
            File.AppendAllLines(@"C:\freddie.txt", new[] { DateTime.Now.ToString(CultureInfo.InvariantCulture), ex.Message, ex.StackTrace });
        }
    }

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
                {
                    var pair = request.Parser.Parse(stream);
                    Logger.Log(requestMessage.RequestUri.ToString(), pair.Key);
                    return pair.Value;
                }
            }
        }
    }
}