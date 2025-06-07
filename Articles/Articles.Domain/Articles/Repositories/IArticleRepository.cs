using Core.Interfaces;

namespace Articles.Domain.Articles.Repositories;

/// <summary>
/// Репозиторий для <see cref="Article"/>
/// </summary>
public interface IArticleRepository : IRepository
{
    /// <summary>
    /// Создать новую статью
    /// </summary>
    public Task CreateAsync(Article article);
    
    /// <summary>
    /// Получить статью
    /// </summary>
    public Task<Article> GetAsync(Guid articleId);

    /// <summary>
    /// Изменить статью
    /// </summary>
    public Task UpdateAsync(Article command);

    /// <summary>
    /// Удалить статью
    /// </summary>
    public Task DeleteAsync(Guid articleId);
}