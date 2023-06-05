using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public Uri? HomepageUrl { get; set; }

    public Uri? LogoUrl { get; set; }

    public Uri? FaviconUrl { get; set; }

    public int NewsArticleId { get; set; }
}

