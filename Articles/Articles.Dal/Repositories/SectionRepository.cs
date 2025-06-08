using Articles.Dal.DbContext;
using Articles.Domain.Articles;
using Articles.Domain.Articles.Dto;
using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Sections;
using Articles.Domain.Sections.Repositories;
using Articles.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace Articles.Dal.Repositories;

/// <inheritdoc />
public class SectionRepository : ISectionRepository
{
    private readonly AppDbContext _appDbContext;

    public SectionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<SectionStats>> GetStatsForAllAsync()
    {
        var queryResult = await _appDbContext.Articles
            .Include(static a => a.ArticleTags)
            .ThenInclude(static at => at.Tag)
            .GroupBy(static a => a.SectionId)
            .Select(static g => new
            {
                SectionId = g.Key,
                ArticlesCount = g.Count(),
                TagsDal = g.First().ArticleTags
            })
            .ToListAsync();

        return queryResult.Select(static r => new SectionStats(r.TagsDal.Select(ts => Tag.Create(ts.Tag.Name)), r.ArticlesCount));
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Article>> GetArticlesAsync(string sectionId)
    {
        var articlesDal = await _appDbContext.Articles
            .Include(static a => a.ArticleTags)
            .ThenInclude(static at => at.Tag)
            .Where(a => a.SectionId == sectionId)
            .ToListAsync();

        var articlesDto = articlesDal.Select(static dal => new ArticleDto
        {
            Id = dal.Id,
            Name = ArticleName.Create(dal.Name),
            CreatedAt = dal.CreatedAt,
            UpdatedAt = dal.UpdatedAt,
            Tags = dal.ArticleTags.Select(static at => Tag.Create(at.Tag.Name)).ToArray()
        });

        return articlesDto.Select(static dto => Article.FromDto(dto));
    }
}