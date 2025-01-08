using System.Diagnostics.CodeAnalysis;

namespace TransferProtocol.Body;

public interface IBody
{
    public MemoryStream Data { get; set; }
    internal static abstract string ContentTypeStatic { get; }
    public string ContentType { get; }
    
    protected static abstract IBody ParseInternal(MemoryStream data);
    
    public byte[] ToBytes();
    
    public static TBody Parse<TBody>(MemoryStream data) where TBody : IBody
    {
        return (TBody)TBody.ParseInternal(data);
    }
    
    public static bool TryParse<TBody>(MemoryStream data, [NotNullWhen(true)] out TBody? body) where TBody : IBody
    {
        try
        {
            body = Parse<TBody>(data);
            return true;
        }
        catch
        {
            body = default;
            return false;
        }
    }
}