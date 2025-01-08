using System.Net;
using System.Net.Sockets;
using TransferProtocol;
using TransferProtocol.Messages;

namespace Tests.WtpTests;

[TestFixture]
public class ServerTests
{
    public readonly WtpServer Server = new WtpServer(new IPEndPoint(IPAddress.Loopback, 7070));
    
    [SetUp]
    public void Setup()
    {
        Server.Start();
    }
    
    [OneTimeTearDown]
    public void Teardown()
    {
        Server.Dispose();
    }

    [Test]
    public void SendRequest()
    {
        var client = new TcpClient();
        client.Connect(IPAddress.Loopback, 7070);
        
        using var stream = client.GetStream();
        using var reader = new StreamReader(stream);
        using var writer = new StreamWriter(stream);
        
        writer.WriteLine("Hello, server!");
        writer.Flush();
        
        var response = reader.ReadLine();
        Assert.That(response, Is.EqualTo("Not implemented"));
    }
}