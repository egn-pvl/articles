namespace Core.Extensions;

/// <summary>
/// Расширения для массивов
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    /// Копировать массив
    /// </summary>
    public static T[] Copy<T>(this T[] original)
    {
        if (original.Length == 0)
        {
            return [];
        }
        
        var copy = new T[original.Length];
        
        original.AsSpan().CopyTo(copy);
        
        return copy;
    }
}