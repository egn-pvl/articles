using Articles.Domain.Articles.Dto;
using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Tags;
using Core.BaseTypes;
using Core.Exceptions.Common;

namespace Articles.Domain.Articles;

/// <summary>
/// Статья
/// </summary>
public class Article : Entity<Guid>
{
    /// <summary>
    /// Максимальное количество тэгов для статьи
    /// </summary>
    public const int TagsCountMax = 256;
    
    /// <summary>
    /// Название
    /// </summary>
    public ArticleName Name { get; private set; }
    
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
    public Article(ArticleName name, IEnumerable<Tag> tags)
    {
        var tagsArray = tags.Distinct().ToArray();
        
        CheckTagsCount(tagsArray.Length);
        
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTimeOffset.UtcNow;
        Tags = tagsArray;
    }

    /// <summary>
    /// Сформировать сущность из DTO
    /// </summary>
    public static Article FromDto(ArticleDto dto)
    {
        var article = new Article(dto.Name, dto.Tags)
        {
            Id = dto.Id,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
            Tags = dto.Tags
        };
        
        return article;
    }

    /// <summary>
    /// Обновить статью
    /// </summary>
    public void Update(ArticleName? name, IEnumerable<Tag>? tags)
    {
        var tagsArray = tags?.Distinct().ToArray();
        
        if (tagsArray != null)
        {
            CheckTagsCount(tagsArray.Length);
        }
        
        Name = name ?? Name;
        Tags = tagsArray != null ? tagsArray : Tags;
        
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Проверить количество передаваемых тэгов на соответствие требованиям
    /// </summary>
    private void CheckTagsCount(int tagsCount)
    {
        if (tagsCount > TagsCountMax)
        {
            throw new TooBigCollectionException(nameof(Tags), tagsCount, TagsCountMax);
        }
    }
}