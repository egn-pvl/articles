using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Tags;

namespace Articles.Domain.Articles.Dto;

/// <summary>
/// Транспортная модель для <see cref="Article"/>
/// </summary>
public record ArticleDto
{
    /// <summary>
    /// ID статьи
    /// </summary>
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Название
    /// </summary>
    public required ArticleName Name { get; init; }
    
    /// <summary>
    /// Дата и время создания
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }
    
    /// <summary>
    /// Дата и время изменения
    /// </summary>
    public required DateTimeOffset? UpdatedAt { get; init; }
    
    /// <summary>
    /// Список тэгов
    /// </summary>
    public required Tag[] Tags { get; init; }
}