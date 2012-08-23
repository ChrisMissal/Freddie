using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class BooleanParser : BaseParser
    {
        protected override JObject Read(string content)
        {
            var json = @"{""success"": " + content + "}";
            return JObject.Parse(json);
        }
    }
}