using Core.Interfaces;

namespace Articles.Domain.Articles.Repositories;

/// <summary>
/// Репозиторий для <see cref="Article"/>
/// </summary>
public interface IArticleRepository : IRepository
{
    /// <summary>
    /// Сохранить статью
    /// </summary>
    /// <remarks>
    /// Если не найдена по ID - будет создана новая. Если найдена - будет обновлена
    /// </remarks>
    public Task CreateAsync(Article article);
    
    /// <summary>
    /// Получить статью
    /// </summary>
    public Task<Article> GetAsync(Guid articleId);

    /// <summary>
    /// Обновить статью
    /// </summary>
    public Task UpdateAsync(Article article);

    /// <summary>
    /// Удалить статью
    /// </summary>
    public Task DeleteAsync(Guid articleId);
}