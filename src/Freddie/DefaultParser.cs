using System.IO;
using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class DefaultParser : IResponseParser
    {
        public Response Parse(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var ret = reader.ReadToEnd();
                dynamic content = JObject.Parse(ret);
                return new Response(content);
            }
        }
    }
}