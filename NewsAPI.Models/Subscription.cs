using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Models;

public class Subscription
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }
}

