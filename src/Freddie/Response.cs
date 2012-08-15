using Newtonsoft.Json.Linq;

namespace Freddie
{
    internal class Response : IResponse
    {
        private readonly JToken _content;

        internal Response(JToken content)
        {
            _content = content;
        }

        public JToken Content
        {
            get { return _content; }
        }

        public virtual bool Success
        {
            get
            {
                return (_content["error"] == null);
            }
        }
    }
}