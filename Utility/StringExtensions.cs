using System.Text;

namespace Utility;

public static class StringExtensions
{
    /// <summary>
    /// Convert the current string to an array of bytes using the specified encoding.
    /// </summary>
    /// <param name="str">The string to convert.</param>
    /// <param name="encoding">The encoding to use. Defaults to <see cref="Encoding.UTF8"/></param>
    /// <returns>The string, converted to bytes.</returns>
    public static byte[] ReadAsBytes(this string str, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;

        return encoding.GetBytes(str);
    }
}