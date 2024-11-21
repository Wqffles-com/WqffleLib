using System.Text;
using Utility;

namespace Tests.Utility;

/// <summary>
/// Tests for <see cref="StringUtilities"/>.
/// </summary>
[TestFixture]
public class StringUtilities
{
    /// <summary>
    /// Converts a string to a byte array using <see cref="StringExtensions.ReadAsBytes(string,Encoding)"/>
    /// </summary>
    [Test]
    public void ReadAsBytes()
    {
        const string str = "Hello, World!";
        var expected = Encoding.UTF8.GetBytes(str);

        var result = str.ReadAsBytes();

        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Converts a byte array to a string using <see cref="ByteArrayExtensions.ReadAsString(byte[],Encoding)"/>
    /// </summary>
    [Test]
    public void ReadFromBytes()
    {
        var bytes = "Hello, World!"u8.ToArray();
        const string expected = "Hello, World!";

        var result = bytes.ReadAsString();
        
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// <inheritdoc cref="ReadAsBytes"/>
    /// </summary>
    /// <remarks>Uses <see cref="Encoding.ASCII"/></remarks>
    [Test]
    public void ReadAsBytesWithEncoding()
    {
        const string str = "Hello, World!";
        var expected = Encoding.ASCII.GetBytes(str);

        var result = str.ReadAsBytes(Encoding.ASCII);

        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// <inheritdoc cref="ReadFromBytes"/>
    /// </summary>
    /// <remarks>Uses <see cref="Encoding.ASCII"/></remarks>
    [Test]
    public void ReadFromBytesWithEncoding()
    {
        var bytes = "Hello, World!"u8.ToArray();
        const string expected = "Hello, World!";

        var result = bytes.ReadAsString(Encoding.ASCII);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}