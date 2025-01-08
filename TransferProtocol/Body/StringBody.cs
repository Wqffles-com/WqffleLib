using System.Text;

namespace TransferProtocol.Body;

public class StringBody : IBody
{
    public MemoryStream Data { get; set; }
    public static string ContentTypeStatic => "plain/string";
    public string ContentType => "plain/string";

    public StringBody(string data)
    {
        Data = new MemoryStream(Encoding.UTF8.GetBytes(data));
    }

    public StringBody(MemoryStream data)
    {
        Data = data;
    }

    public StringBody(byte[] data)
    {
        var stream = new MemoryStream();
        stream.Write(data);
        Data = stream;
    }
    
    public static IBody ParseInternal(MemoryStream data)
    {
        return new StringBody(data);
    }

    public byte[] ToBytes()
    {
        return Data.ToArray();
    }
    
    public override string ToString() => Encoding.UTF8.GetString(Data.ToArray());
}