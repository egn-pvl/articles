using System.Security.Cryptography;
using System.Text;
using Articles.Domain.Tags;
using Core.BaseTypes;

namespace Articles.Domain.Sections;

/// <summary>
/// Раздел
/// </summary>
public record Section : ValueObject
{
    /// <summary>
    /// Максимальная длина названия
    /// </summary>
    public const int MaxNameLength = 1024;
    
    /// <summary>
    /// ID раздела
    /// </summary>
    public string SectionId { get; private init; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// Список тэгов
    /// </summary>
    public SortedSet<Tag> Tags { get; private init; }

    /// <summary>
    /// ctor
    /// </summary>
    public Section(IEnumerable<Tag> tags)
    {
        Tags = new(tags.Distinct());
        Name = GenerateName();
        SectionId = GenerateSectionId();
    }

    private string GenerateName()
    {
        var joined = string.Join(',', Tags.Select(static el => el.Value));
        if (joined.Length > MaxNameLength)
        {
            return joined[..MaxNameLength];
        }

        return joined;
    }

    /// <summary>
    /// Сгенерировать ID раздела
    /// </summary>
    private string GenerateSectionId()
    {
        var sha = SHA256.Create();
        var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(Name));
        
        return Convert.ToHexString(hash[..8]).ToLowerInvariant();
    }
}