using Articles.Domain.Tags;
using Core.Dal;

namespace Articles.Dal.DalModels;

/// <summary>
/// Dal-модель для <see cref="Tag"/>
/// </summary>
public record TagDal : DalModel<Guid>
{
    /// <summary>
    /// Название тэга
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Упорядоченный список тэов для статьи
    /// </summary>
    public List<ArticleTagDal> ArticleTags { get; init; } = new();
}