using System.Text;

namespace TransferProtocol.Messages;

public sealed class WtpRequestMessage : MessageBase
{
    public required RequestMethod Method { get; set; }
    
    public required Uri Uri { get; set; }
    
    protected override string CreateBase() => $"{Method.ToString()} {Uri.ToString()}";

    public static async Task<WtpRequestMessage> ParseAsync(string data)
    {
        var lines = data.Split('\n');

        var baseLine = lines[1];
        var method = baseLine.Split(' ')[0];
        var uri = new Uri(baseLine.Split(' ')[1]);
        
        var message = new WtpRequestMessage
        {
            Method = Enum.Parse<RequestMethod>(method),
            Uri = uri
        };

        await message.Initialize(new MemoryStream(Encoding.UTF8.GetBytes(data)));
        
        return message;
    }
}