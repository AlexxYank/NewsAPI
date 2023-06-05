using NewsAPI.Infrastructure.Interfaces;
using NewsAPI.Models;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task SubscribeAsync(string email)
    {
        await _subscriptionRepository.Subscribe(new Subscription { Email = email, CreatedAt = DateTime.Now, IsActive = true } );
    }

    public async Task CancelSubscriptionAsync(int userId)
    {
        await _subscriptionRepository.Cancel(userId);
    }

    public async Task RenewSubscriptionAsync(int userId)
    {
        await _subscriptionRepository.Renew(userId);
    }
}

