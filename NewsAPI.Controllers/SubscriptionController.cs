using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Controllers;

[ApiController]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        this._subscriptionService = subscriptionService;
    }

    [Authorize]
    [HttpPost("api/subscribe")]
    [ProducesResponseType(typeof(List<Subscription>), 200)]
    public async Task<IActionResult> Subscribe(string email)
    {
        await _subscriptionService.SubscribeAsync(email);

        return Ok("User subscribed successfully.");
    }
}

