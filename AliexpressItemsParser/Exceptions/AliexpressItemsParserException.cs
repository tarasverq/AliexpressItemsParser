using System;
using System.Runtime.Serialization;

namespace AliexpressItemsParser.Exceptions;

[Serializable]
public class AliexpressItemsParserException : Exception
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //
    private const string jsonStringKey = "JsonString";
    public AliexpressItemsParserException()
    {
    }

    public AliexpressItemsParserException(string message) : base(message)
    {
    } 
    public AliexpressItemsParserException(string message, string json) : base(message)
    {
        Data.Add(jsonStringKey, json);
    }

    public AliexpressItemsParserException(string message, Exception inner) : base(message, inner)
    {
    }

    protected AliexpressItemsParserException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }

    public override string ToString()
    {

        if (Data[jsonStringKey] is string json && !string.IsNullOrWhiteSpace(json))
            return base.ToString() + $"{Environment.NewLine}{json}";
        return base.ToString();
    }
}