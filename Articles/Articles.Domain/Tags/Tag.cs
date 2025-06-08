using Core.BaseTypes;
using Core.Exceptions.Common;

namespace Articles.Domain.Tags;

/// <summary>
/// Тэг
/// </summary>
public record Tag : SimpleValueObject<Tag, string>, IComparable<Tag>
{
    /// <summary>
    /// Максимальное количество символов
    /// </summary>
    public const int MaxLength = 256;
    
    protected override string Normalize(string value)
    {
        return value.Trim().ToLowerInvariant();
    }

    protected override void Validate(string value)
    {
        if (value.Length > MaxLength)
        {
            throw new IncorrectValueException(this, value, $"max length is {MaxLength} characters");
        }
    }

    /// <inheritdoc />
    public int CompareTo(Tag? other)
    {
        if (other is null)
        {
            return 1;
        }

        return string.Compare(Value, other.Value, StringComparison.InvariantCulture);
    }
}