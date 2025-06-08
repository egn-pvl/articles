using Core.BaseTypes;

namespace Core.Exceptions.Common;

/// <summary>
/// Значение не может быть null
/// </summary>
public class ValueCanNotBeNullException : AppException
{
    public ValueCanNotBeNullException(ValueObject valueObject)
        :base($"Value of {valueObject.GetType().Name} can not be null"){}
}