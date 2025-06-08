using System.ComponentModel.DataAnnotations;
using Articles.Api.Conrollers.Articles.Request;
using Articles.Api.Conrollers.Articles.Response;
using Articles.Application.Articles.Services.Interfaces;
using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Tags;
using Core.Api;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Api.Conrollers.Articles;

/// <summary>
/// API статей
/// </summary>
[Route("article")]
public class ArticleController : AppController
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }
    
    /// <summary>
    /// Создать новую статью
    /// </summary>
    [HttpPost]
    [ProducesResponseType<ArticleCreateResponse>(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] ArticleCreateRequest request)
    {
        var articleId = await _articleService.CreateAsync(new()
        {
            Name = ArticleName.Create(request.Name),
            Tags = request.Tags.Select(static el => Tag.Create(el))
        });
        
        var response = new ArticleCreateResponse
        {
            ArticleId = articleId
        };

        return Created(string.Empty, response);
    }

    /// <summary>
    /// Получить статью по ID
    /// </summary>
    [HttpGet("{articleId:guid}")]
    [ProducesResponseType<ArticleResponse>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(
        [FromRoute, Required] Guid articleId)
    {
        var article = await _articleService.GetAsync(articleId);
        
        var response = new ArticleResponse
        {
            Id = article.Id,
            Name = article.Name.Value,
            CreatedAt = article.CreatedAt,
            UpdatedAt = article.UpdatedAt,
            Tags = article.Tags.Select(static el => el.Value)
        };

        return Ok(response);
    }
    
    /// <summary>
    /// Изменить статью
    /// </summary>
    [HttpPatch("{articleId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PatchAsync(
        [FromRoute, Required] Guid articleId,
        [FromBody, Required] ArticlePatchRequest request)
    {
        await _articleService.UpdateAsync(new()
        {
            ArticleId = articleId,
            Name = request.Name != null ? ArticleName.Create(request.Name) : null,
            Tags = request.Tags?.Select(static el => Tag.Create(el))
        });

        return NoContent();
    }
    
    /// <summary>
    /// Удалить статью
    /// </summary>
    [HttpDelete("{articleId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute, Required] Guid articleId)
    {
        await _articleService.DeleteAsync(articleId);
        return NoContent();
    }
}