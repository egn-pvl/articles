using Articles.Application.Articles.Commands;
using Articles.Application.Articles.Services.Interfaces;
using Articles.Domain.Articles;
using Articles.Domain.Articles.Repositories;

namespace Articles.Application.Articles.Services;

/// <inheritdoc />
public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(ArticleCreateCommand command)
    {
        var article = new Article(command.Name, command.Tags);
        await _articleRepository.CreateAsync(article);
        return article.Id;
    }

    /// <inheritdoc />
    public async Task<Article> GetAsync(Guid articleId)
    {
        return await _articleRepository.GetAsync(articleId);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(ArticleUpdateCommand command)
    {
        var article = await _articleRepository.GetAsync(command.ArticleId);
        article.Update(command.Name, command.Tags);
        await _articleRepository.UpdateAsync(article);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid articleId)
    {
        await _articleRepository.DeleteAsync(articleId);
    }
}