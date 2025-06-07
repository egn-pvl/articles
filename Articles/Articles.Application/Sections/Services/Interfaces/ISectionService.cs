using Articles.Domain.Articles;
using Articles.Domain.Sections.ValueObjects;

namespace Articles.Application.Sections.Services.Interfaces;

/// <summary>
/// Бизнес-логика для <see cref="Section"/>
/// </summary>
public interface ISectionService
{
    /// <summary>
    /// Получить список всех разделов
    /// </summary>
    Task<IEnumerable<Section>> GetAllAsync();

    /// <summary>
    /// Получить список статей раздела
    /// </summary>
    Task<IEnumerable<Article>> GetArticlesAsync(string sectionId);
}