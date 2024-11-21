using System.Text;
using Utility;

namespace Tests;

public class StringUtilities
{
    [Test]
    public void ReadAsBytes()
    {
        const string str = "Hello, World!";
        var expected = Encoding.UTF8.GetBytes(str);

        var result = str.ReadAsBytes();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReadFromBytes()
    {
        var bytes = "Hello, World!"u8.ToArray();
        const string expected = "Hello, World!";

        var result = bytes.ReadAsString();
        
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void ReadAsBytesWithEncoding()
    {
        const string str = "Hello, World!";
        var expected = Encoding.ASCII.GetBytes(str);

        var result = str.ReadAsBytes(Encoding.ASCII);

        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void ReadFromBytesWithEncoding()
    {
        var bytes = "Hello, World!"u8.ToArray();
        const string expected = "Hello, World!";

        var result = bytes.ReadAsString(Encoding.ASCII);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}