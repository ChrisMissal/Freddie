using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class IntParser : BaseParser
    {
        protected override JObject Read(string content)
        {
            var json = @"{""value"": " + content + "}";
            return JObject.Parse(json);
        }
    }
}