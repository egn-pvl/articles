using Articles.Domain.Articles;
using Articles.Domain.Sections;

namespace Articles.Application.Sections.Services.Interfaces;

/// <summary>
/// Бизнес-логика для <see cref="Section"/>
/// </summary>
public interface ISectionService
{
    /// <summary>
    /// Получить статистику по всем разделам
    /// </summary>
    Task<IEnumerable<SectionStats>> GetStatsForAllAsync();

    /// <summary>
    /// Получить список статей раздела
    /// </summary>
    Task<IEnumerable<Article>> GetArticlesAsync(string sectionId);
}