using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAPI.Infrastructure.Interfaces;
using NewsAPI.Infrastructure.Persistence;

namespace NewsAPI.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<NewsDbContext>(options => options.UseSqlServer(ConnectionString.BuildConnection()));

        services.AddScoped<INewsArticleRepository, NewsArticleRepository>();

        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
    }
}

