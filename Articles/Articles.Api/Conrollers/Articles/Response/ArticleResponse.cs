using System.Text.Json.Serialization;

namespace Articles.Api.Conrollers.Articles.Response;

/// <summary>
/// Возвращаемая модель статьи
/// </summary>
public record ArticleResponse
{
    /// <summary>
    /// ID статьи
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Название
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// Дата и время создания
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTimeOffset CreatedAt { get; init; }
    
    /// <summary>
    /// Дата и время изменения
    /// </summary>
    [JsonPropertyName("ureatedAt")]
    public required DateTimeOffset? UpdatedAt { get; init; }
    
    /// <summary>
    /// Список тэгов
    /// </summary>
    [JsonPropertyName("tags")]
    public required IEnumerable<string> Tags { get; init; }
}