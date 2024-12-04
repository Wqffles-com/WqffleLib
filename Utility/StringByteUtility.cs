using System.Text;

namespace Utility;

public static class StringByteUtility
{
    public static byte[] ReadAsBytes(this string value, Encoding? encoding = null) =>
        (encoding ?? Encoding.UTF8).GetBytes(value);
    
    public static string ReadAsString(this byte[] value, Encoding? encoding = null) =>
        (encoding ?? Encoding.UTF8).GetString(value);
}