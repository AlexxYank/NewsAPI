using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;

namespace NewsAPI.Infrastructure.Persistence;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
    {
    }

    public DbSet<NewsArticle> NewsArticles { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = ConnectionString.BuildConnection();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

