using Microsoft.EntityFrameworkCore;
using NewsAPI.Infrastructure.Interfaces;
using NewsAPI.Models;

namespace NewsAPI.Infrastructure.Persistence;

public class NewsArticleRepository : INewsArticleRepository
{
    private readonly NewsDbContext _newsDbContext;

    public NewsArticleRepository(NewsDbContext newsDbContext)
    {
        _newsDbContext = newsDbContext;
    }

    public async Task<List<NewsArticle>> GetAllNewsArticlesAsync()
    {
        return await _newsDbContext.Set<NewsArticle>()
            .Include(a => a.Publisher)
            .Include(a => a.Tickers)
            .Include(a => a.Keywords)
            .ToListAsync();
    }

    public async Task<List<NewsArticle>> GetNewsArticlesFromTodayAsync(int days)
    {
        var fromDate = DateTimeOffset.UtcNow.AddDays(-days);
        return await _newsDbContext.Set<NewsArticle>()
            .Include(a => a.Publisher)
            .Include(a => a.Tickers)
            .Include(a => a.Keywords)
            .Where(a => a.PublishedUtc >= fromDate)
            .ToListAsync();
    }

    public async Task<List<NewsArticle>> GetNewsArticlesByInstrumentAsync(string instrumentName, int limit = 10)
    {
        return await _newsDbContext.Set<NewsArticle>()
            .Include(a => a.Publisher)
            .Include(a => a.Tickers)
            .Include(a => a.Keywords)
            .Where(a => a.Tickers.Any(t => t.Name.Equals(instrumentName, StringComparison.OrdinalIgnoreCase)))
            .Take(limit)
            .ToListAsync();
    }

    public async Task<List<NewsArticle>> GetNewsArticlesByContentAsync(string text)
    {
        return await _newsDbContext.Set<NewsArticle>()
            .Include(a => a.Publisher)
            .Include(a => a.Tickers)
            .Include(a => a.Keywords)
            .Where(a => a.Title.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                        a.Description.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<List<NewsArticle>> GetLatestNewsForConversionToolAsync()
    {
        var newsArticles = await GetAllNewsArticlesAsync();

        var uniqueInstruments = newsArticles.SelectMany(a => a.Tickers)
                                            .Select(t => t.Name)
        .Distinct()
                                            .Take(5);

        var latestNewsByInstruments = new List<NewsArticle>();

        foreach (var instrument in uniqueInstruments)
        {
            var latestNews = await GetNewsArticlesByInstrumentAsync(instrument, limit: 1);

            if (latestNews.Count > 0)
            {
                latestNewsByInstruments.Add(latestNews[0]);
            }
        }

        return latestNewsByInstruments;
    }
}
