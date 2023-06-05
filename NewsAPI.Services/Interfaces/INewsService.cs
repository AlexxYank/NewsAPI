﻿using NewsAPI.Models;

namespace NewsAPI.Services.Interfaces;

public interface INewsService
{
    Task<List<NewsArticle>> GetAllNewsArticlesAsync();

    Task<List<NewsArticle>> GetNewsArticlesFromTodayAsync(int days);

    Task<List<NewsArticle>> GetNewsArticlesByInstrumentAsync(string instrumentName, int limit = 10);

    Task<List<NewsArticle>> GetNewsArticlesByContentAsync(string text);

    Task<List<NewsArticle>> GetLatestNewsForConversionToolAsync();
}

