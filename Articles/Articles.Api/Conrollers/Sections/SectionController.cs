using System.ComponentModel.DataAnnotations;
using Articles.Api.Conrollers.Articles.Response;
using Articles.Api.Conrollers.Sections.Response;
using Articles.Application.Sections.Services.Interfaces;
using Core.Api;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Api.Conrollers.Sections;

/// <summary>
/// API разделов
/// </summary>
[Route("section")]
public class SectionController : AppController
{
    private readonly ISectionService _sectionService;

    public SectionController(ISectionService sectionService)
    {
        _sectionService = sectionService;
    }

    /// <summary>
    /// Получить список разделов
    /// </summary>
    [HttpGet("list/all")]
    [ProducesResponseType<IEnumerable<SectionResponse>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync()
    {
        var sections = await _sectionService.GetStatsForAllAsync();
        var response = sections
            .OrderByDescending(static el => el.ArticlesCount)
            .Select(static el => new SectionResponse
            {
                SectionId = el.SectionId,
                Name = el.Name
            });

        return Ok(response);
    }
    
    /// <summary>
    /// Получить список статей раздела
    /// </summary>
    [HttpGet("{sectionId}/article/list")]
    [ProducesResponseType<IEnumerable<ArticleResponse>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetArticlesAsync(
        [FromRoute, Required] string sectionId)
    {
        var articles = await _sectionService.GetArticlesAsync(sectionId);
        var response = articles
            .OrderByDescending(static el => el.UpdatedAt ?? el.CreatedAt)
            .Select(static el => new ArticleResponse()
            {
                Id = el.Id,
                Name = el.Name.Value,
                CreatedAt = el.CreatedAt,
                UpdatedAt = el.UpdatedAt,
                Tags = el.Tags.Select(static el => el.Value)
            });

        return Ok(response);
    }
}