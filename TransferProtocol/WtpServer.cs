using System.Net;
using System.Net.Sockets;
using TransferProtocol.RequestIdentifiers;

namespace TransferProtocol;

public class WtpServer(IPEndPoint endPoint) : IDisposable, IAsyncDisposable
{
    public readonly IPEndPoint ListeningOn = endPoint;
    public ServerState State { get; private set; } = ServerState.Stopped;

    private readonly TcpListener _listener = new TcpListener(endPoint);
    private readonly Dictionary<IRequestIdentifier, RequestDelegate> _endPoints = new();
    
    public void Start()
    {
        State = ServerState.Running;
        
        _listener.Start();
        new Thread(StartInternal).Start();
    }
    
    private void StartInternal()
    {
        while (State == ServerState.Running)
        {
            try
            {
                var client = _listener.AcceptTcpClient();
                _ = HandleClient(client);
            }
            catch (SocketException)
            {
                break;
            }
        }
    }
    
    private async Task HandleClient(TcpClient client)
    {
        var stream = client.GetStream();
        var reader = new StreamReader(stream);
        var writer = new StreamWriter(stream);
        
        while (State == ServerState.Running)
        {
            var request = await reader.ReadLineAsync();
            if (request == null)
            {
                break;
            }
            
            var response = HandleRequest(request);
            await writer.WriteLineAsync(response);
            await writer.FlushAsync();
        }
    }
    
    private string HandleRequest(string request)
    {
        return "Not implemented";
    }

    public void Dispose()
    {
        State = ServerState.Stopped;
        _listener.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        State = ServerState.Stopped;
        _listener.Dispose();
        
        return ValueTask.CompletedTask;
    }
}