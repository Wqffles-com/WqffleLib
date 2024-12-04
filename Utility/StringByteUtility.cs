using System.Text;

namespace Utility;

/// <summary>
/// Utility methods related to byte[] and string.
/// </summary>
public static class StringByteUtility
{
    /// <summary>
    /// Convert a string to a byte array.
    /// </summary>
    /// <param name="value">The string to convert</param>
    /// <param name="encoding">The encoding to use. Defaults to <see cref="Encoding.UTF8"/></param>
    /// <returns>A byte array corresponding to the string.</returns>
    public static byte[] ReadAsBytes(this string value, Encoding? encoding = null) =>
        (encoding ?? Encoding.UTF8).GetBytes(value);
    
    /// <summary>
    /// Convert a byte array to a string.
    /// </summary>
    /// <param name="value">The byte array to convert</param>
    /// <param name="encoding">The encoding to use. Defaults to <see cref="Encoding.UTF8"/></param>
    /// <returns>A string corresponding to the byte array.</returns>
    public static string ReadAsString(this byte[] value, Encoding? encoding = null) =>
        (encoding ?? Encoding.UTF8).GetString(value);
}