using Core.Dal;

namespace Articles.Dal.DalModels;

/// <summary>
/// Модель для связки <see cref="ArticleDal"/> и <see cref="TagDal"/>: "многие-ко-многим"
/// </summary>
public record ArticleTagDal : DalModel
{
    /// <summary>
    /// ID статьи
    /// </summary>
    public required Guid ArticleId { get; init; }

    /// <summary>
    /// Модель статьи
    /// </summary>
    public ArticleDal Article { get; init; } = null!;
    
    /// <summary>
    /// ID тэга
    /// </summary>
    public required Guid TagId { get; init; }

    /// <summary>
    /// Модель тэга
    /// </summary>
    public TagDal Tag { get; init; } = null!;
    
    /// <summary>
    /// Порядковый номер
    /// </summary>
    public required int Order { get; init; }
}