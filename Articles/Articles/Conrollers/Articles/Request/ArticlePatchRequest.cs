using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Articles.Domain.Articles;
using Articles.Domain.Articles.ValueObjects;

namespace Articles.Api.Conrollers.Articles.Request;

/// <summary>
/// Запрос на изменение статьи
/// </summary>
public record ArticlePatchRequest
{
    /// <summary>
    /// Название
    /// </summary>
    [JsonPropertyName("name")]
    [MaxLength(ArticleName.MaxLength)]
    public required string? Name { get; init; }
    
    /// <summary>
    /// Список тэгов
    /// </summary>
    [JsonPropertyName("tags")]
    [MaxLength(Article.TagsCountMax)]
    public required IEnumerable<string>? Tags { get; init; }
}