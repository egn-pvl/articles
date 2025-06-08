using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Articles.Domain.Articles;
using Articles.Domain.Articles.ValueObjects;

namespace Articles.Api.Conrollers.Articles.Request;

/// <summary>
/// Запрос на создание статьи
/// </summary>
public record ArticleCreateRequest
{
    /// <summary>
    /// Название
    /// </summary>
    [JsonPropertyName("name")]
    [Required, MaxLength(ArticleName.MaxLength)]
    public required string Name { get; init; }
    
    /// <summary>
    /// Список тэгов
    /// </summary>
    [JsonPropertyName("tags")]
    [Required, MaxLength(Article.TagsCountMax)]
    public required IEnumerable<string> Tags { get; init; }
}