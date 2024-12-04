namespace Utility;

/// <summary>
/// Any utility methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableUtility
{
    /// <summary>
    /// Trim the start of the <see cref="IEnumerable{T}"/> based on the instance.
    /// </summary>
    /// <param name="enumerable">The enumerable to be trimmed.</param>
    /// <param name="instance">The instance to trim of.</param>
    /// <param name="equalityComparer">Comparer of 2 instances of <see cref="T"/></param>
    /// <typeparam name="T">The type of the instance to trim.</typeparam>
    /// <returns>An <see cref="IEnumerable{T}"/>, trimmed at the start of any <see cref="instance"/>s</returns>
    public static IEnumerable<T> TrimStart<T>(this IEnumerable<T> enumerable, T? instance = default, IEqualityComparer<T>? equalityComparer = default)
    {
        equalityComparer ??= EqualityComparer<T>.Default;
        return enumerable.SkipWhile(x => equalityComparer.Equals(x, instance));
    }
    
    /// <summary>
    /// Trim the end of the <see cref="IEnumerable{T}"/> based on the instance.
    /// </summary>
    /// <param name="enumerable">The enumerable to be trimmed.</param>
    /// <param name="instance">The instance to trim of.</param>
    /// <param name="equalityComparer">Comparer of 2 instances of <see cref="T"/></param>
    /// <typeparam name="T">The type of the instance to trim.</typeparam>
    /// <returns>An <see cref="IEnumerable{T}"/>, trimmed at the end of any <see cref="instance"/>s</returns>
    public static IEnumerable<T> TrimEnd<T>(this IEnumerable<T> enumerable, T? instance = default, IEqualityComparer<T>? equalityComparer = default)
    {
        equalityComparer ??= EqualityComparer<T>.Default;
        return enumerable.Reverse().SkipWhile(x => equalityComparer.Equals(x, instance)).Reverse();
    }
    
    /// <summary>
    /// Trim the start and end of the <see cref="IEnumerable{T}"/> based on the instance.
    /// </summary>
    /// <param name="enumerable">The enumerable to be trimmed.</param>
    /// <param name="instance">The instance to trim of.</param>
    /// <param name="equalityComparer">Comparer of 2 instances of <see cref="T"/></param>
    /// <typeparam name="T">The type of the instance to trim.</typeparam>
    /// <returns>An <see cref="IEnumerable{T}"/>, trimmed of any <see cref="instance"/>s</returns>
    public static IEnumerable<T> Trim<T>(this IEnumerable<T> enumerable, T? instance = default, IEqualityComparer<T>? equalityComparer = default) =>
        enumerable.TrimStart(instance, equalityComparer).TrimEnd(instance, equalityComparer);
}