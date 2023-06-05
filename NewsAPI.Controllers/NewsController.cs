using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Controllers;

[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [Authorize]
    [HttpGet("api/news")]
    [ProducesResponseType(typeof(List<NewsArticle>), 200)]
    public async Task<IActionResult> GetAllNewsArticles()
    {
        var newsArticles = await _newsService.GetAllNewsArticlesAsync();
        return Ok(newsArticles);
    }

    [Authorize]
    [HttpGet("api/news/today/{days}")]
    [ProducesResponseType(typeof(List<NewsArticle>), 200)]
    public async Task<IActionResult> GetNewsArticlesFromToday(int days)
    {
        var newsArticles = await _newsService.GetNewsArticlesFromTodayAsync(days);
        return Ok(newsArticles);
    }

    [Authorize]
    [HttpGet("api/news/instrument/{instrumentName}")]
    [ProducesResponseType(typeof(List<NewsArticle>), 200)]
    public async Task<IActionResult> GetNewsArticlesByInstrument(string instrumentName, int limit = 10)
    {
        var newsArticles = await _newsService.GetNewsArticlesByInstrumentAsync(instrumentName, limit);
        return Ok(newsArticles);
    }

    [Authorize]
    [HttpGet("api/news/search")]
    [ProducesResponseType(typeof(List<NewsArticle>), 200)]
    public async Task<IActionResult> GetNewsArticlesByContent(string text)
    {
        var newsArticles = await _newsService.GetNewsArticlesByContentAsync(text);
        return Ok(newsArticles);
    }

    [HttpGet("api/news/latest")]
    [ProducesResponseType(typeof(List<NewsArticle>), 200)]
    public async Task<IActionResult> GetLatestNewsForConversionTool()
    {
        var latestArticles = await _newsService.GetLatestNewsForConversionToolAsync();
       
        return Ok(latestArticles);
    }
}
