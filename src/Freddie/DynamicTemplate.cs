namespace Freddie
{
    [Handles("templateAdd", typeof(IntParser))]
    [Handles("templateDel", typeof(BooleanParser))]
    [Handles("templateInfo", typeof(ArrayParser))]
    [Handles("templateUndel", typeof(BooleanParser))]
    [Handles("templateUpdate", typeof(BooleanParser))]
    [Handles("templates", typeof(ArrayParser))]
    internal class DynamicTemplate : DynamicBase
    {
        internal DynamicTemplate(Endpoint endpoint) : base(endpoint)
        {
        }
    }
}