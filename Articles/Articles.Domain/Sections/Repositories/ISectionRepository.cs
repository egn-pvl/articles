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
        /// Получить список всех разделов
        /// </summary>
        Task<IEnumerable<Section>> GetAllAsync();

        /// <summary>
        /// Получить список статей раздела
        /// </summary>
        Task<IEnumerable<Article>> GetArticlesAsync(string sectionId);
    }
}