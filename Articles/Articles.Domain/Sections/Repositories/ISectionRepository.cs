using Articles.Domain.Articles;
using Core.Interfaces;

namespace Articles.Domain.Sections.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="Section"/>
    /// </summary>
    public interface ISectionRepository : IRepository
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
}