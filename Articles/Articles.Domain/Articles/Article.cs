using Articles.Domain.Tags.ValueObjects;
using Core.BaseTypes;
using Core.Extensions;

namespace Articles.Domain.Articles;

/// <summary>
/// Статья
/// </summary>
public class Article : Entity<Guid>
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; private init; }
    
    /// <summary>
    /// Дата и время изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; private set; }
    
    /// <summary>
    /// Список тэгов
    /// </summary>
    public Tag[] Tags { get; private set; }

    /// <summary>
    /// ctor
    /// </summary>
    public Article(string name, Tag[] tags)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTimeOffset.UtcNow;
        Tags = tags.Copy();
    }

    /// <summary>
    /// Обновить статью
    /// </summary>
    public void Update(string? name, Tag[]? tags)
    {
        Name = name ?? Name;
        Tags = tags != null ? tags.Copy() : Tags;
        
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}