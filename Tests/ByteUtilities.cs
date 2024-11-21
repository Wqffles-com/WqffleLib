using Utility;

namespace Tests;

public class ByteUtilities
{
    [Test(ExpectedResult = new byte[] {1, 2, 3, 4, 5})]
    public byte[] TrimEnd()
    {
        var array = new byte[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        return array.TrimEnd();
    }

    [Test(ExpectedResult = new byte[] { 1, 2, 3, 4, 5 })]
    public byte[] TrimStart()
    {
        var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 };

        return array.TrimStart();
    }

    [Test(ExpectedResult = new byte[] { 1, 2, 3, 4, 5 })]
    public byte[] Trim()
    {
        var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        return array.Trim();
    }
}