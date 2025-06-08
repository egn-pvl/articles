using Articles.Application.Sections.Services.Interfaces;
using Articles.Domain.Articles;
using Articles.Domain.Sections;
using Articles.Domain.Sections.Repositories;

namespace Articles.Application.Sections.Services;

/// <inheritdoc />
public class SectionService : ISectionService
{
    private readonly ISectionRepository _sectionRepository;

    public SectionService(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Section>> GetAllAsync()
    {
        return await _sectionRepository.GetAllAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Article>> GetArticlesAsync(string sectionId)
    {
        return await _sectionRepository.GetArticlesAsync(sectionId);
    }
}