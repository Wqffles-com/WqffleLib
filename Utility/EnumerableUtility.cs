namespace Utility;

public static class EnumerableUtility
{
    public static IEnumerable<T> TrimStart<T>(this IEnumerable<T> enumerable, T? instance = default, IEqualityComparer<T>? equalityComparer = default)
    {
        equalityComparer ??= EqualityComparer<T>.Default;
        return enumerable.SkipWhile(x => equalityComparer.Equals(x, instance));
    }
    
    public static IEnumerable<T> TrimEnd<T>(this IEnumerable<T> enumerable, T? instance = default, IEqualityComparer<T>? equalityComparer = default)
    {
        equalityComparer ??= EqualityComparer<T>.Default;
        return enumerable.Reverse().SkipWhile(x => equalityComparer.Equals(x, instance)).Reverse();
    }
    
    public static IEnumerable<T> Trim<T>(this IEnumerable<T> enumerable, T? instance = default, IEqualityComparer<T>? equalityComparer = default) =>
        enumerable.TrimStart(instance, equalityComparer).TrimEnd(instance, equalityComparer);
}