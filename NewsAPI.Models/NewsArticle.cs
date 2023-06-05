using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Models;

public class NewsArticle
{
    [Key]
    public int Id { get; set; }

    public string ResultId { get; set; }

    public Publisher Publisher { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public DateTimeOffset PublishedUtc { get; set; }

    public Uri ArticleUrl { get; set; }

    public ICollection<Ticker> Tickers { get; set; } = new List<Ticker>();

    public Uri? ImageUrl { get; set; }

    public string? Description { get; set; }

    public ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();

    public Uri? AmpUrl { get; set; }
}

