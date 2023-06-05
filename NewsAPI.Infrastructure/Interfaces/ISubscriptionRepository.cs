using NewsAPI.Models;

namespace NewsAPI.Infrastructure.Interfaces;

public interface ISubscriptionRepository
{
    Task Subscribe(Subscription subscription);

    Task Renew(int subscriptionId);

    Task Cancel(int subscriptionId);

    Task<bool> CheckSubscription(int subscriptionId);
}

