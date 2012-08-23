using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal abstract class BaseParser : IResponseParser
    {
        protected abstract JObject Read(string content);

        public KeyValuePair<string, Response> Parse(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var response = GetResponse(json);
                return new KeyValuePair<string, Response>(json, response);
            }
        }

        private Response GetResponse(string json)
        {
            if (json.StartsWith(@"{""error"":"))
            {
                var content = JObject.Parse(json);
                return new Response(content);
            }

            return new Response(Read(json));
        }
    }
}