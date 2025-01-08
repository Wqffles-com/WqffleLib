using System.Text;

namespace TransferProtocol.Messages;

public class WtpResponseMessage : MessageBase
{
    public required ResponseCode ResponseCode { get; set; }

    protected override string CreateBase() => ((int)ResponseCode).ToString();

    public static async Task<WtpResponseMessage> Parse(string data)
    {
        var lines = data.Split('\n');
        
        var responseCode = (ResponseCode)int.Parse(lines[0]);
        
        var message = new WtpResponseMessage
        {
            ResponseCode = responseCode
        };
        
        await message.Initialize(new MemoryStream(Encoding.UTF8.GetBytes(data)));

        return message;
    }
}