namespace Core.Exceptions;

/// <summary>
/// Базовое исключение приложения
/// </summary>
public abstract class AppException : Exception
{
    public AppException(string message) : base(message){}
    public AppException(string message, Exception innerException) : base(message, innerException){}
}