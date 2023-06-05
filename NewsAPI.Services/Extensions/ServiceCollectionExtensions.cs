using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<INewsService, NewsService>();

        services.AddScoped<ISubscriptionService, SubscriptionService>();
    }

    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewsAPI", Version = "v1" });
        });
    }

    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                //Configure
                options.Authority = "https://test-authentication-provider.com";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = "test-audience",
                };
            });
    }
}

