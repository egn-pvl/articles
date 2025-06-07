using Articles.Application.Articles.Commands;
using Articles.Domain.Articles;

namespace Articles.Application.Articles.Services.Interfaces;

/// <summary>
/// Бизнес-логика для <see cref="Article"/>
/// </summary>
public interface IArticleService
{
    /// <summary>
    /// Создать новую статью
    /// </summary>
    Task<Guid> CreateAsync(ArticleCreateCommand command);
    
    /// <summary>
    /// Получить статью
    /// </summary>
    Task<Article> GetAsync(Guid articleId);

    /// <summary>
    /// Изменить статью
    /// </summary>
    Task UpdateAsync(ArticleUpdateCommand command);

    /// <summary>
    /// Удалить статью
    /// </summary>
    Task DeleteAsync(Guid articleId);
}