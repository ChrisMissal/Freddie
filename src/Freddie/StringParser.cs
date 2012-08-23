using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class StringParser : BaseParser
    {
        protected override JObject Read(string content)
        {
            var json = @"{""text"": " + content + "}";
            return JObject.Parse(json);
        }
    }
}