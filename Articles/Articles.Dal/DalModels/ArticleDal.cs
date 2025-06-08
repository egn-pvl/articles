using Articles.Domain.Articles;
using Core.Dal;

namespace Articles.Dal.DalModels;

/// <summary>
/// Dal-модель для <see cref="Article"/>
/// </summary>
public record ArticleDal : DalModel<Guid>
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Дата и время создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// Дата и время изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// ID секции
    /// </summary>
    public string SectionId { get; set; } = null!;

    /// <summary>
    /// Упорядоченный список тэгов для статьи
    /// </summary>
    public List<ArticleTagDal> ArticleTags { get; set; } = [];
}