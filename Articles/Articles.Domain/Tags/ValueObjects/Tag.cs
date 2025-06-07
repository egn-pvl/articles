using Core.BaseTypes;

namespace Articles.Domain.Tags.ValueObjects;

/// <summary>
/// Тэг
/// </summary>
public record Tag : ValueObject
{
    /// <summary>
    /// Название тэга
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// ctor
    /// </summary>
    public Tag(string name)
    {
        Name = name.Trim().ToLowerInvariant();
    }
}