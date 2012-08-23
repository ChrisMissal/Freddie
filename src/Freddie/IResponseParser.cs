using System.Collections.Generic;
using System.IO;

namespace Freddie
{
    internal interface IResponseParser
    {
        KeyValuePair<string, Response> Parse(Stream stream);
    }
}