using System.Text;

namespace Utility;

public static class ByteArrayExtensions
{
    /// <summary>
    /// Convert a byte array to a string using the specified encoding.
    /// </summary>
    /// <param name="bytes">The bytes to be converted.</param>
    /// <param name="encoding">The encoding to use. Defaults to <see cref="Encoding.UTF8"/></param>
    /// <returns>The <see cref="bytes"/>, converted to a string.</returns>
    public static string ReadAsString(this byte[] bytes, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;
        
        return encoding.GetString(bytes);
    }

    /// <summary>
    /// Trim the byte array of any leading or trailing zeros.
    /// </summary>
    /// <param name="bytes">The bytes to be trimmed.</param>
    /// <returns>The <see cref="bytes"/>, trimmed of leading and trailing zeros.</returns>
    public static byte[] Trim(this byte[] bytes)
    {
        return bytes.TrimStart().TrimEnd();
    }

    /// <summary>
    /// Trim the byte array of any leading zeros.
    /// </summary>
    /// <param name="bytes">The bytes to be trimmed.</param>
    /// <returns>The <see cref="bytes"/>, trimmed of leading zeros.</returns>
    public static byte[] TrimStart(this byte[] bytes)
    {
        var i = 0;
        while (i < bytes.Length && bytes[i] == 0)
        {
            i++;
        }
        
        return bytes[i..];
    }
    
    /// <summary>
    /// Trim the byte array of any trailing zeros.
    /// </summary>
    /// <param name="bytes">The bytes to be trimmed.</param>
    /// <returns>The <see cref="bytes"/>, trimmed of trailing zeros.</returns>
    public static byte[] TrimEnd(this byte[] bytes)
    {
        var i = bytes.Length - 1;
        while (i >= 0 && bytes[i] == 0)
        {
            i--;
        }
        
        return bytes[..(i + 1)];
    }
}