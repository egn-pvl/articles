using Articles.Domain.Articles;
using Articles.Domain.Articles.Repositories;
using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Tags;

namespace Articles.Dal.Repositories;

/// <inheritdoc />
public class ArticleRepository : IArticleRepository
{
    /// <inheritdoc />
    public Task CreateAsync(Article article)
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task<Article> GetAsync(Guid articleId)
    {
        return Task.FromResult(Article.FromDto(new()
        {
            Id = articleId,
            Name = ArticleName.Create("Моковая статья"),
            CreatedAt = DateTimeOffset.UtcNow.AddDays(-5),
            UpdatedAt = DateTimeOffset.UtcNow.AddHours(-1),
            Tags =
            [
                Tag.Create("мок"),
                Tag.Create("mock")
            ]
        }));
    }

    /// <inheritdoc />
    public Task UpdateAsync(Article command)
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task DeleteAsync(Guid articleId)
    {
        return Task.CompletedTask;
    }
}