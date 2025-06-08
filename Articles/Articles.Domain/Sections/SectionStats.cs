using Articles.Domain.Tags;

namespace Articles.Domain.Sections;

public record SectionStats : Section
{
    /// <summary>
    /// Количество статей в разделе
    /// </summary>
    public int ArticlesCount { get; private init; }
    
    public SectionStats(IEnumerable<Tag> tags, int articlesCount) : base(tags)
    {
        ArticlesCount = articlesCount;
    }
}