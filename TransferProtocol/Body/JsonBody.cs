using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace TransferProtocol.Body;

public class JsonBody : IBody
{
    public required MemoryStream Data { get; set; }
    public static string ContentTypeStatic => "data/json";
    public string ContentType => "data/json";

    public static IBody ParseInternal(MemoryStream data)
    {
        return new JsonBody { Data = data };
    }
    
    public byte[] ToBytes()
    {
        return Data.ToArray();
    }
    
    public T? Parse<T>()
    {
        return JsonSerializer.Deserialize<T>(Data.ToArray());
    }
    
    public bool TryParse<T>([NotNullWhen(true)] out T? body)
    {
        try
        {
            body = Parse<T>() ?? throw new InvalidOperationException("Failed to parse JSON body");
            return true;
        }
        catch
        {
            body = default;
            return false;
        }
    }
}