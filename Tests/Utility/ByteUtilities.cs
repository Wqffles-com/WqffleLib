using Utility;

namespace Tests.Utility;

/// <summary>
/// Tests for <see cref="ByteUtilities"/>.
/// </summary>
[TestFixture]
public class ByteUtilities
{
    /// <summary>
    /// Test the <see cref="ByteArrayExtensions.TrimEnd(byte[])"/> method.
    /// </summary>
    /// <returns>A byte[] of [ 1, 2, 3, 4, 5 ]</returns>
    [Test(ExpectedResult = new byte[] {1, 2, 3, 4, 5})]
    public byte[] TrimEnd()
    {
        var array = new byte[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        return array.TrimEnd();
    }

    /// <summary>
    /// Test the <see cref="ByteArrayExtensions.TrimStart(byte[])"/> method.
    /// </summary>
    /// <returns>A byte[] of [ 1, 2, 3, 4, 5 ]</returns>
    [Test(ExpectedResult = new byte[] { 1, 2, 3, 4, 5 })]
    public byte[] TrimStart()
    {
        var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 };

        return array.TrimStart();
    }

    /// <summary>
    /// Test the <see cref="ByteArrayExtensions.Trim(byte[])"/> method.
    /// </summary>
    /// <returns>A byte[] of [ 1, 2, 3, 4, 5 ]</returns>
    [Test(ExpectedResult = new byte[] { 1, 2, 3, 4, 5 })]
    public byte[] Trim()
    {
        var array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        return array.Trim();
    }
}