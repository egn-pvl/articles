using Articles.Dal.DalModels;
using Articles.Dal.DbContext;
using Articles.Domain.Articles;
using Articles.Domain.Articles.Dto;
using Articles.Domain.Articles.Repositories;
using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Sections;
using Articles.Domain.Tags;
using Core.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace Articles.Dal.Repositories;

/// <inheritdoc />
public class ArticleRepository : IArticleRepository
{
    private readonly AppDbContext _appDbContext;

    public ArticleRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc />
    public async Task CreateAsync(Article article)
    {
        // Получаем список dal-моделей тэгов
        var tagsDal = await GetTagsDalAsync(article.Tags);
        
        // Вычисляем раздел стати
        var section = new Section(article.Tags);
        
        // Формируем dal-модель статьи
        var articleDal = new ArticleDal()
        {
            Id = article.Id,
            Name = article.Name.Value,
            CreatedAt = article.CreatedAt,
            UpdatedAt = article.UpdatedAt,
            SectionId = section.SectionId,
            ArticleTags = article.Tags.Select((tag, index) => new ArticleTagDal
            {
                ArticleId = article.Id,
                TagId = tagsDal.First(t => t.Name == tag.Value).Id,
                Order = index
            }).ToList()
        };

        // Сохраняем статью
        await _appDbContext.Articles.AddAsync(articleDal);

        // Сохраняем
        await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<Article> GetAsync(Guid articleId)
    {
        var articleDal = await GetArticleDalAsync(articleId);

        var articleDto = new ArticleDto
        {
            Id = articleDal.Id,
            Name = ArticleName.Create(articleDal.Name),
            CreatedAt = articleDal.CreatedAt,
            UpdatedAt = articleDal.UpdatedAt,
            Tags = articleDal.ArticleTags
                .OrderBy(static at => at.Order)
                .Select(static at => Tag.Create(at.Tag.Name))
                .ToArray()
        };
        var article = Article.FromDto(articleDto);
        return article;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Article article)
    {
        using var transaction = await _appDbContext.Database.BeginTransactionAsync();

        try
        {
            // Получаем статью
            var articleDal = await GetArticleDalAsync(article.Id);
        
            // Удаляем старые привязки к тэгам, сохраняем
            _appDbContext.ArticleTags.RemoveRange(articleDal.ArticleTags);
            await _appDbContext.SaveChangesAsync();
        
            // Создаём новые привязки к тэгам
            var tagsDal = (await GetTagsDalAsync(article.Tags)).ToList();
            var newArticleTags = article.Tags.Select((tag, index) => new ArticleTagDal
            {
                ArticleId = article.Id,
                TagId = tagsDal.First(t => t.Name == tag.Value).Id,
                Order = index
            }).ToList();

            // Проставляем новые свойства
            articleDal.Name = article.Name.Value;
            articleDal.CreatedAt = article.CreatedAt;
            articleDal.UpdatedAt = article.UpdatedAt;
            articleDal.ArticleTags = newArticleTags;
        
            // Обновляем данные
            _appDbContext.Articles.Update(articleDal);

            // Сохраняем
            await _appDbContext.SaveChangesAsync();
            
            // Коммитим
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid articleId)
    {
        await _appDbContext.Articles
            .Where(a => a.Id == articleId)
            .ExecuteDeleteAsync();
    }

    /// <summary>
    /// Получить dal-модели тэгов
    /// </summary>
    private async Task<IEnumerable<TagDal>> GetTagsDalAsync(Tag[] tags)
    {
        var tagNames = tags.Select(static el => el.Value);
        
        // Получаем существующие тэги
        var existingTags = await _appDbContext.Tags
            .Where(tagDal => tagNames.Contains(tagDal.Name))
            .ToListAsync();
        
        // Сохраняем недостающие тэги
        var newTags = tagNames
            .Except(existingTags.Select(static tagDal => tagDal.Name))
            .Select(static tagName => new TagDal
            {
                Id = Guid.NewGuid(),
                Name = tagName
            }).ToList();

        await _appDbContext.Tags.AddRangeAsync(newTags);

        var result = existingTags.Concat(newTags);
        return result;
    }

    /// <summary>
    /// Получить статью
    /// </summary>
    /// <exception cref="EntityNotFoundException{Article,Guid}">Статья не найдена</exception>
    private async Task<ArticleDal> GetArticleDalAsync(Guid articleId)
    {
        var articleDalOrDefault = await _appDbContext.Articles
            .Include(static a => a.ArticleTags)
            .ThenInclude(static at => at.Tag)
            .FirstOrDefaultAsync(a => a.Id == articleId);

        if (articleDalOrDefault == null)
        {
            throw new EntityNotFoundException<Article, Guid>(articleId);
        }

        return articleDalOrDefault;
    }
}