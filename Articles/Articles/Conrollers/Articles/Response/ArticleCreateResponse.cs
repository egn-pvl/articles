using System.Text.Json.Serialization;

namespace Articles.Api.Conrollers.Articles.Response;

/// <summary>
/// Результат создания статьи
/// </summary>
public record ArticleCreateResponse
{
    /// <summary>
    /// ID статьи
    /// </summary>
    [JsonPropertyName("articleId")]
    public required Guid ArticleId { get; init; }
}