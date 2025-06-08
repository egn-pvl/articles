using System.Text.Json.Serialization;

namespace Articles.Api.Conrollers.Sections.Response;

/// <summary>
/// Возвращаемая модель раздела
/// </summary>
public record SectionResponse
{
    /// <summary>
    /// ID раздела
    /// </summary>
    [JsonPropertyName("sectionId")]
    public required string SectionId { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}