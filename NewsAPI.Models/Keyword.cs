using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Models;

public class Keyword
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public int NewsArticleId { get; set; }
}

