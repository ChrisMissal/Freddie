using System.IO;

namespace Freddie
{
    internal interface IResponseParser
    {
        Response Parse(Stream stream);
    }
}