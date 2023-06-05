using Microsoft.EntityFrameworkCore;
using NewsAPI.Infrastructure.Interfaces;
using NewsAPI.Models;

namespace NewsAPI.Infrastructure.Persistence;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly NewsDbContext _newsDbContext;

    public SubscriptionRepository(NewsDbContext newsDbContext)
    {
        _newsDbContext = newsDbContext;
    }

    public async Task Subscribe(Subscription subscription)
    {
        await this._newsDbContext.Subscriptions.AddAsync(subscription);
        await _newsDbContext.SaveChangesAsync();
    }

    public async Task Renew(int subscriptionId)
    {
        var subscription = await this._newsDbContext.Subscriptions.FindAsync(subscriptionId);
        if (subscription != null)
        {
            subscription.IsActive = true;
            await this._newsDbContext.SaveChangesAsync();
        }
    }

    public async Task Cancel(int subscriptionId)
    {
        var subscription = await this._newsDbContext.Subscriptions.FindAsync(subscriptionId);
        if (subscription != null)
        {
            subscription.IsActive = false;
            await this._newsDbContext.SaveChangesAsync();
        }
    }

    public async Task<bool> CheckSubscription(int subscriptionId)
    {
        return await this._newsDbContext.Subscriptions.AnyAsync(s => s.Id == subscriptionId);
    }
}

