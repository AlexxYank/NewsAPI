namespace NewsAPI.Services.Interfaces;

public interface ISubscriptionService
{
    Task SubscribeAsync(string email);

    Task CancelSubscriptionAsync(int userId);

    Task RenewSubscriptionAsync(int userId);
}

