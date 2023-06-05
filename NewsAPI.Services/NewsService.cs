using NewsAPI.Infrastructure.Interfaces;
using NewsAPI.Models;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Services;

public class NewsService : INewsService
{
    private readonly INewsArticleRepository _newsArticleRepository;

    public NewsService(INewsArticleRepository newsArticleRepository)
    {
        _newsArticleRepository = newsArticleRepository;
    }

    public async Task<List<NewsArticle>> GetAllNewsArticlesAsync()
    {
        return await _newsArticleRepository.GetAllNewsArticlesAsync();
    }

    public async Task<List<NewsArticle>> GetNewsArticlesFromTodayAsync(int days)
    {
        return await _newsArticleRepository.GetNewsArticlesFromTodayAsync(days);
    }

    public async Task<List<NewsArticle>> GetNewsArticlesByInstrumentAsync(string instrumentName, int limit = 10)
    {
        return await _newsArticleRepository.GetNewsArticlesByInstrumentAsync(instrumentName, limit);
    }

    public async Task<List<NewsArticle>> GetNewsArticlesByContentAsync(string text)
    {
        return await _newsArticleRepository.GetNewsArticlesByContentAsync(text);
    }

    public async Task<List<NewsArticle>> GetLatestNewsForConversionToolAsync()
    {
        return await _newsArticleRepository.GetLatestNewsForConversionToolAsync();
    }
}

