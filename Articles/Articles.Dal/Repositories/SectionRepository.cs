using Articles.Domain.Articles;
using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Sections;
using Articles.Domain.Sections.Repositories;
using Articles.Domain.Tags;

namespace Articles.Dal.Repositories;

/// <inheritdoc />
public class SectionRepository : ISectionRepository
{
    private readonly IEnumerable<Tag> _mockTagCollection =
    [
        Tag.Create("mock"),
        Tag.Create("мок")
    ];
    
    /// <inheritdoc />
    public Task<IEnumerable<Section>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Section>>([
            new(_mockTagCollection, 1)
        ]);
    }

    /// <inheritdoc />
    public Task<IEnumerable<Article>> GetArticlesAsync(string sectionId)
    {
        return Task.FromResult<IEnumerable<Article>>([Article.FromDto(new()
        {
            Id = Guid.NewGuid(),
            Name = ArticleName.Create("Моковая статья"),
            CreatedAt = DateTimeOffset.UtcNow.AddDays(-5),
            UpdatedAt = DateTimeOffset.UtcNow.AddHours(-1),
            Tags = _mockTagCollection.ToArray()
        })]);
    }
}