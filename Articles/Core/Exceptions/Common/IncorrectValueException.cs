using Core.BaseTypes;

namespace Core.Exceptions.Common;

/// <summary>
/// Некорректное значение
/// </summary>
public class IncorrectValueException : AppException
{
    public IncorrectValueException(ValueObject valueObject, object value, string reason)
        :base($"Value {value} of {valueObject.GetType().Name} is incorrect: {reason}"){}
}