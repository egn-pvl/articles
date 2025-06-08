namespace Core.Exceptions.Common;

/// <summary>
/// Слишком большая коллекция
/// </summary>
public class TooBigCollectionException : AppException
{
    public TooBigCollectionException(string name, int length, int maxLength)
        : base($"Collection {name} is too long. Current length = {length}, max length = {maxLength}"){}
}