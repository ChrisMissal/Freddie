using System.Dynamic;

namespace Freddie
{
    internal class Response : DynamicObject, IResponse
    {
        private readonly dynamic _content;

        internal Response(dynamic content)
        {
            _content = content;
        }

        public dynamic Content
        {
            get { return _content; }
        }

        public bool Success
        {
            get
            {
                return _content.error == null;
            }
        }
    }
}