using TransferProtocol;
using TransferProtocol.Body;
using TransferProtocol.Messages;

namespace Tests.WtpTests;

[TestFixture]
public class GenericTests
{
    [Test]
    public async Task ParseRequest()
    {
        var expected = new WtpRequestMessage
        {
            Method = RequestMethod.Get,
            Uri = new Uri("http://localhost:7070/heythere"),
            Body = new StringBody("Hey there!")
        };

        var actual = await WtpRequestMessage.ParseAsync(expected.ToString());
        Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
    }
}