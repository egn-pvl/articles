using Core.BaseTypes;
using Core.Exceptions.Common;

namespace Articles.Domain.Articles.ValueObjects;

/// <summary>
/// Название статьи
/// </summary>
public sealed record ArticleName : SimpleValueObject<ArticleName, string>
{
    
    /// <summary>
    /// Максимальное количество символов
    /// </summary>
    public const int MaxLength = 256;
    
    protected override string Normalize(string value)
    {
        return value.Trim();
    }

    protected override void Validate(string value)
    {
        if (value.Length > MaxLength)
        {
            throw new IncorrectValueException(this, value, $"max length is {MaxLength} characters");
        }
    }
}