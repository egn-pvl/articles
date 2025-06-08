using Core.Exceptions.Common;

namespace Core.BaseTypes;

/// <summary>
/// Простой ValueObject с одним значением
/// </summary>
public abstract record SimpleValueObject<TSelf, TValue> : ValueObject
    where TSelf : SimpleValueObject<TSelf, TValue>, new()
{
    public static TSelf Create(TValue rawValue)
    {
        var instance = new TSelf();
        
        if (rawValue == null)
        {
            throw new ValueCanNotBeNullException(instance);
        }
        
        var normalizedValue = instance.Normalize(rawValue);
        instance.Validate(normalizedValue);
        instance.Value = normalizedValue;
        return instance;
    }

    /// <summary>
    /// Значение
    /// </summary>
    public TValue Value { get; private set; } = default!;

    /// <summary>
    /// Нормализовать значение
    /// </summary>
    protected abstract TValue Normalize(TValue value);
    
    /// <summary>
    /// Проверить значение на соответствие требованиям
    /// </summary>
    protected abstract void Validate(TValue value);
}